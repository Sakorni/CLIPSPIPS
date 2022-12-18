using System.Data;
using System.Diagnostics;

namespace ISTER
{
    public partial class Form1 : Form
    {
        public static Dictionary<string, string> facts = new();
        /// <summary>
        /// ключ - id факта, значение - id правила
        /// </summary>
        public static Dictionary<string, string> facts_to_rules = new(); 
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
        private Dictionary<string, string> Get_facts(string path)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
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
            var required = selectedRule.ToString()!.Split(":")[0].Trim();
            var was_found = false;
            HashSet<string> inventory = chosen_facts;
            var openRules = rules.Values.ToHashSet();
            List<string> outStr = new();
            while (!end)
            {
                end = true;
                foreach(var oRule in openRules)
                {
                    if (oRule.compare(inventory.ToList()))
                    {
                        inventory.Add(oRule.conseq);
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
                return;
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
        private void clear_process(string prec, 
            ref Dictionary<string, List<string>> in_process,
            ref HashSet<string> visited)
        {
            Queue<string> q = new();
            q.Enqueue(prec);
            while(q.Count > 0)
            {
                var p = q.Dequeue();
                foreach (var proc in in_process)
                {
                    if (proc.Value.Contains(p))
                    {
                        proc.Value.Remove(p);
                        if (proc.Value.Count == 0)
                        {
                            in_process.Remove(proc.Key);
                            visited.Add(proc.Key);
                            q.Enqueue(proc.Key);
                        }
                    }
                }
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
            Dictionary<string, List<string>> in_process = new();
            Stack<string> s = new();
            Stack<List<string>> output = new();
            bool can_create = true;

            var ffact = item!.Split(":")[0].Trim();
            s.Push(ffact);

            while(s.Count > 0)
            {
                List<string> factOut = new();
                var fact = s.Pop();
                if (visited.Contains(fact))
                {
                    continue;
                }
                factOut.Add($"Необходим факт {fact} \"{facts[fact]}\"");

                var rule = rules[facts_to_rules[fact]];
                var missing_precs = rule.preconds;
                if (missing_precs == null)
                {
                    factOut.Add("Для вывода факта ничего не требуется, однако он отсутствует в инвентаре");
                    can_create = false;
                    break;
                }
                
                factOut.Add($"Для него нужно правило {rule}");

                factOut.Add($"Для правила необходимы факты: {string.Join(", ",missing_precs)}");

                foreach(var prec in missing_precs)
                {
                    if (visited.Contains(prec))
                    {
                        factOut.Add($"Факт {prec} \"{facts[prec]}\" был получен ранее");
                        continue;
                    }
                    if (in_process.ContainsKey(prec))
                    {
                        factOut.Add($"Факт {prec} \"{facts[prec]}\" в обработке");
                        continue;
                    }

                    if (!in_process.ContainsKey(fact))
                    {
                        in_process.Add(fact, new List<string>());
                    }
                    in_process[fact].Add(prec);

                    if (inventory.Contains(prec))
                    {
                        factOut.Add($"Факт {prec} \"{facts[prec]}\" содержится в инвентаре");
                        clear_process(prec, ref in_process, ref visited);
                        continue;
                    }
                    s.Push(prec);
                }
                output.Push(factOut);
            }
            if (!can_create || in_process.Count > 0)
            {
                outputBox.AppendText("Вывод невозможен");
                return;
            }
            foreach(var strLst in output)
            {
                foreach (var str in strLst)
                {
                    outputBox.AppendText(str);
                    outputBox.AppendText(Environment.NewLine);
                }
                outputBox.AppendText("------------");
                outputBox.AppendText(Environment.NewLine);
            }
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}