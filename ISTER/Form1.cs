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
        //

        public Form1()
        {
            InitializeComponent();
            facts = Get_facts("../../../facts.txt");
            rules = Get_rules("../../../rules.txt");
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
            chosenFactsBox.Items.Add(readable_form);
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selected = chosenFactsBox.SelectedItem;
            if (selected == null) return;
            var fact = selected.ToString().Split(":")[0];
            var readable_form = $"{fact}: {facts[fact]}";
            chosen_facts.Remove(fact);
            chosenFactsBox.Items.Remove(readable_form);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
            var selected_rule = ruleBox.SelectedItem;
            if (chosen_facts.Count == 0 || selected_rule == null)
            {
                outputBox.AppendText("Ой, а ничего не выбрали, с чем мне работать-то?");
                return;
            };

            var rerun = true;
            var found = false;
            var possibleRules = rules.Values.ToHashSet();
            var looking_for = selected_rule.ToString().Split(":")[0].Trim();
            List<string> output = new();
            while (rerun)
            {
                rerun = false;
                foreach(var rule in possibleRules)
                {
                    if (rule.compare(chosen_facts.ToList()))
                    {
                        chosen_facts.Add(rule.conseq);
                        output.Add(rule.ToString());
                        possibleRules.Remove(rule);
                        if (rule.conseq == looking_for)
                        {
                            rerun = false;
                            found = true;
                            break;
                        }
                        rerun = true;
                    }
                    
                }
            }
            if (!found)
            {
                outputBox.AppendText("Нельзя");
                return;
            }

            outputBox.AppendText("Льзя");
            foreach (var s in output)
            {
                outputBox.AppendText(s);
                outputBox.AppendText(Environment.NewLine);
            }
        }

        private void clearChosenButton_Click(object sender, EventArgs e)
        {
            chosen_facts.Clear();
            chosenFactsBox.Items.Clear();
        }

        private void factsFromRuleButton_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
            var item = ruleBox.SelectedItem.ToString();
            if (item == null)
            {
                outputBox.AppendText("Nothing to write home about m8");
                return;
            }

            var firstFact = item.Split(":")[0].Trim();

            HashSet<string> inventory = chosen_facts;
            HashSet<string> colors = new();
            List<string> outp = new();
            bool answer = Recursion(firstFact, ref inventory, ref colors, ref outp);
            if (answer)
            {
            outputBox.AppendText("Можно");
            outputBox.AppendText(Environment.NewLine);
            foreach (var s in outp)
            {
                outputBox.AppendText(s);
                outputBox.AppendText(Environment.NewLine);
            }
            }
            else
            {
                outputBox.AppendText("Нельзя");
                outputBox.AppendText(Environment.NewLine);
            }

        }

        private bool Recursion(string fact, ref HashSet<string> inventory, ref HashSet<String> colors, ref List<string> outp)
        {
            colors.Add(fact);
            outp.Add($"Хотим получить: {fact} ({facts[fact]})");

            if (!facts_to_rules.ContainsKey(fact))
            {
                if (!inventory.Contains(fact))
                {
                    return false;
                }
                outp.Add("А для его вывода никаких правил и не надо");
                return true;
            }

            var ruleID = facts_to_rules[fact];
            var rule = rules[ruleID];
            outp.Add($"Понадобится правило: {rule}");
            List<string>precond = new();
            bool all = true;
            foreach (var p in rule.preconds)
            {
                if (!inventory.Contains(p))
                {
                    precond.Add(p);
                }

            }
            if (precond.Count == 0) return true;

            outp.Add($"Для работы этого правила нужны ещё факты: {string.Join(", ", precond)}");
            bool answer = true;
            foreach (var factCond in precond)
            {
                if (colors.Contains(factCond))
                {
                    outp.Add($"Факт {factCond} ({facts[fact]}) мы уже получили ранее (надеюсь)");
                    
                    continue;
                }
                answer &= Recursion(factCond, ref inventory, ref colors, ref outp);
            }
            return answer;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ruleBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}