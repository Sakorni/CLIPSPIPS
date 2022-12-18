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
        Clips clips;
        public Form1()
        {
            InitializeComponent();
            facts = Get_facts("../../../../facts.txt");
            rules = Get_rules("../../../../rules.txt");
            load();
            Clips.parseRules("../../../../rules.txt", "../../../../rules.clp");
            clips = new Clips("../../../../rules.clp");
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
            var required = selectedRule.ToString()!.Split(":")[0].Trim();
            HashSet<string> inventory = chosen_facts;

            if (inventory.Contains(required))
            {
                outputBox.AppendText("Целевой факт уже в инвентаре");
                return;
            }

            clips.clear();
            foreach (var item in inventory)
            {
                clips.pushFact(item);
            }
            clips.run();
            var factVals = clips.getFactVals();
            
            if (!factVals["item"].Contains(required))
            {
                outputBox.AppendText("Вывод факта не существует");
                return;
            }
            outputBox.AppendText("Вывод:");
            outputBox.AppendText(Environment.NewLine);
            foreach (var r in factVals["precept"])
            {
                outputBox.AppendText($"{rules[r].ToString()}");
                outputBox.AppendText(Environment.NewLine);
                if (rules[r].conseq == required)
                {
                    break;
                }
            }
        }

        private void clearChosenButton_Click(object sender, EventArgs e)
        {
            chosen_facts.Clear();
            chosenBox.Items.Clear();
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

        private void factsFromRuleButton_Click(object sender, EventArgs e)
        {
            Clips.parseRules("../../../../rules.txt", "../../../../rules.clp");
        }
        private void ruleBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}