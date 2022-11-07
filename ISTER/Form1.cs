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
            if (chosen_facts.Count == 0)
            {
                outputBox.AppendText("Ой, а ничего не выбрали, с чем мне работать-то?");
                return;
            };
            var rerun = true;
            var possibleRules = rules.Values.ToHashSet();
            while (rerun)
            {
                rerun = false;
                foreach(var rule in possibleRules)
                {
                    if (rule.compare(chosen_facts.ToList()))
                    {
                        chosen_facts.Add(rule.conseq);
                        outputBox.AppendText(rule.ToString());
                        outputBox.AppendText(Environment.NewLine);
                        possibleRules.Remove(rule);
                        rerun = true;
                    }
                }
            }
            if(outputBox.Text.Length == 0)
            {
                outputBox.AppendText("Не, бро, сорян, из этого вообще ничего не сварить");
            }
        }

        private void clearChosenButton_Click(object sender, EventArgs e)
        {
            chosen_facts.Clear();
            chosenBox.Items.Clear();
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

            HashSet<string> colors = new();
            Queue<string> q = new();
            q.Enqueue(firstFact);
            while(q.Count > 0)
            {
                outputBox.AppendText("------------------");
                outputBox.AppendText(Environment.NewLine);
                var fact = q.Dequeue();
                colors.Add(fact);
                outputBox.AppendText($"Хотим получить: {fact} ({facts[fact]})");
                outputBox.AppendText(Environment.NewLine);
                
                if (!facts_to_rules.ContainsKey(fact))
                {
                    outputBox.AppendText("А для его вывода никаких правил и не надо");
                    outputBox.AppendText(Environment.NewLine);
                    continue;
                }

                var ruleID = facts_to_rules[fact];
                var rule = rules[ruleID];
                outputBox.AppendText($"Понадобится правило: {rule}");
                outputBox.AppendText(Environment.NewLine);
                var precond = rule.preconds;
                outputBox.AppendText($"Для работы этого правила нужны факты: {string.Join(", ",precond)}");
                outputBox.AppendText(Environment.NewLine);
                foreach(var factCond in precond)
                {
                    if (colors.Contains(factCond))
                    {
                        outputBox.AppendText($"Факт {factCond} ({facts[fact]}) мы уже получили ранее (надеюсь)");
                        outputBox.AppendText(Environment.NewLine);
                        continue;
                    }
                    q.Enqueue(factCond);
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