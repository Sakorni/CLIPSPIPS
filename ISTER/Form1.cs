using System.Data;

namespace ISTER
{
    public partial class Form1 : Form
    {
        public static SortedDictionary<string, string> facts = new();
        /// <summary>
        /// ключ - id факта, значение - id правила
        /// </summary>
        public static SortedDictionary<string, string> facts_to_rules = new(); 
        private static Dictionary<string, Rule> rules = new();
        private static HashSet<string> chosen_facts = new();
        /// <summary>
        /// Ключ - факт, значение - какие факты нужны для получения этого факта
        /// Имитация (мудрого) дерева
        /// </summary>
        private static Dictionary<string, List<string>> facts_tree = new();

        public Form1()
        {
            InitializeComponent();
            facts = Get_facts("../../../facts.txt");
            rules = Get_rules("../../../rules.txt");
            build_tree();
            load();
        }

        /// <summary>
        /// Загрузить факты в списки
        /// </summary>
        private void load()
        {
            foreach (var item in facts.Keys)
            {
                    factsBox.Items.Add( $"{item}: {facts[item]}");
            }
            foreach(var item in facts_to_rules.Keys)
            {
                ruleBox.Items.Add($"{item}: {facts[item]}");
            }
        }
        /// <summary>
        /// Считывает факты из файла.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private SortedDictionary<string, string> Get_facts(string path)
        {
            SortedDictionary<string, string> res = new SortedDictionary<string, string>();
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.StartsWith("//")) continue;
                try {
                    var t = line.Split("#");
                    res.Add(t[0].Trim(), t[1].Trim());
                } catch { }
            }
            return res;
        }
        /// <summary>
        /// Считывает из файла правила, также заполняет facts_to_rules.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Dictionary<string, Rule> Get_rules(string path)
        {
            Dictionary<string, Rule> res = new();
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.StartsWith("//")) continue;
                try
                {
                    var r = new Rule(line);
                    res.Add(r.Name, r);
                    facts_to_rules.Add(r.conseq, r.Name);
                }
                catch { }
            }
            return res;
        }

        internal static Dictionary<string, Rule> Rules { get => rules; set => rules = value; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selected = factsBox.SelectedItem;
            if (selected == null) return;
            var fact = selected.ToString().Split(":")[0];
            var readable_form = $"{fact}: {facts[fact]}";
            if (chosen_facts.Contains(fact)) return;
            chosen_facts.Add(fact);
            chosenBox.Items.Add(readable_form);
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selected = chosenBox.SelectedItem;
            if (selected == null) return;
            var fact = selected.ToString().Split(":")[0];
            var readable_form = $"{fact}: {facts[fact]}";
            chosen_facts.Remove(fact);
            chosenBox.Items.Remove(readable_form);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
            var selectedRule = ruleBox.SelectedItem;
            if (chosen_facts.Count == 0 || selectedRule == null)
            {
                outputBox.AppendText("Что-то было не выбрано");
                return;
            };
            var end = false;
            var openRules = rules.Values.ToHashSet();
            var required = selectedRule.ToString()!.Split(":")[0].Trim();
            var was_found = false;
            List<string> outStr = new();
            while (!end)
            {
                end = true;
                foreach(var oRule in openRules)
                {
                    if (oRule.compare(chosen_facts.ToList()))
                    {
                        chosen_facts.Add(oRule.conseq);
                        outStr.Add(oRule.ToString());
                        openRules.Remove(oRule);
                        if(oRule.conseq == required)
                        {
                            end = true;
                            was_found = true;
                            break;
                        }
                        end = false;
                    }
                }
            }
            if (!was_found)
            {
                outputBox.AppendText("Вывод факта не существует");
            }
            outputBox.AppendText("Вывод:");
            outputBox.AppendText(Environment.NewLine);
            foreach (var str in outStr)
            {
                outputBox.AppendText(str);
                outputBox.AppendText(Environment.NewLine);
            }
        }

        private void clearChosenButton_Click(object sender, EventArgs e)
        {
            chosen_facts.Clear();
            chosenBox.Items.Clear();
        }

        private void build_tree()
        {
            foreach(var fact in facts.Keys)
            {
                List<string> preconditions = null;
                if (facts_to_rules.ContainsKey(fact))
                {
                    preconditions = preconditions_from_fact(fact);
                }
                facts_tree.Add(fact, preconditions);
            }
        }

        private void factsFromRuleButton_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
            if (chosen_facts.Count == 0 || ruleBox.SelectedItem == null)
            {
                outputBox.AppendText("Что-то было не выбрано");
                return;
            };

            var item = ruleBox.SelectedItem.ToString();

            HashSet<string> inventory = chosen_facts;
            HashSet<string> visited = new();
            Stack<string> s = new();
            
            var ffact = item!.Split(":")[0].Trim();
            s.Push(ffact);
            while(s.Count > 0)
            {
                outputBox.AppendText("------------------");
                outputBox.AppendText(Environment.NewLine);
                var fact = s.Pop();
                visited.Add(fact);
                outputBox.AppendText($"Хотим получить: {fact} ({facts[fact]})");
                outputBox.AppendText(Environment.NewLine);

                var missing_precs = facts_tree[fact];
                if (missing_precs == null)
                {
                    outputBox.AppendText("Для вывода правила не нужны факты");
                    outputBox.AppendText(Environment.NewLine);
                    continue;
                }
                
                /*
                var ruleID = facts_to_rules[fact];
                var rule = rules[ruleID];
                outputBox.AppendText($"Понадобится правило: {rule}"); // TODO: можешь избавиться от правил, тогда использование дерева будет более оправданным, но не будешь говорить, какие факты нужны
                outputBox.AppendText(Environment.NewLine);
                */

                outputBox.AppendText($"Для получения этого факта нам нужны факты: {string.Join(", ",missing_precs)}");
                outputBox.AppendText(Environment.NewLine);

                foreach(var prec in missing_precs)
                {
                    if (inventory.Contains(prec))
                    {

                    }
                    if (visited.Contains(prec))
                    {
                        outputBox.AppendText($"Факт {prec} ({facts[prec]}) мы уже получили ранее (надеюсь)");
                        outputBox.AppendText(Environment.NewLine);
                        continue;
                    }
                    s.Push(prec);
                }
            }
            outputBox.AppendText("Ну вот и всё! Террария - это просто!");
            outputBox.AppendText(Environment.NewLine);


        }
        /// <summary>
        /// Возвращает список фактов, которые нужны для выполнения правила, возвращающего предоставленный факт
        /// </summary>
        /// <param name="fact"></param>
        /// <returns></returns>
        private List<string> preconditions_from_fact(string fact)
        {
            return rules[facts_to_rules[fact]].preconds;
        }

        private void ruleBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}