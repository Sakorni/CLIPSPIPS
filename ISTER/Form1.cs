using System.Data;
using System.Linq;

namespace ISTER
{
    public partial class Form1 : Form
    {
        public static Dictionary<string, string> facts = new();
        /// <summary>
        /// ���� - id �����, �������� - id �������
        /// </summary>
        public static Dictionary<string, List<string>> facts_to_rules = new(); 
        private static Dictionary<string, List<Rule>> rules = new();
        private static HashSet<string> chosen_facts = new();
        /// <summary>
        /// ���� - ����, �������� - ����� ����� ����� ��� ��������� ����� �����
        /// �������� (�������) ������
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
        /// ��������� ����� � ������
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
        /// ��������� ����� �� �����.
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
        /// ��������� �� ����� �������, ����� ��������� facts_to_rules.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Dictionary<string, List<Rule>> Get_rules(string path)
        {
            Dictionary<string, List<Rule>> res = new();
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.StartsWith("//")) continue;
                try
                {
                    var r = new Rule(line);
                    if (!res.ContainsKey(r.Name))
                    {
                        res.Add(r.Name, new List<Rule>());
                    }
                    res[r.Name].Add(r);

                    if (!facts_to_rules.ContainsKey(r.conseq))
                    {
                        facts_to_rules.Add(r.conseq, new List<string>());
                    }
                    facts_to_rules[r.conseq].Add(r.Name);
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
                outputBox.AppendText("���-�� ���� �� �������");
                return;
            };
            var end = false;
            var required = selectedRule.ToString()!.Split(":")[0].Trim();
            var was_found = false;
            HashSet<string> inventory = chosen_facts;
            var openRuleNames = facts_to_rules.Where(x => inventory.Contains(x.Key)).Select(x => x.Value)
            .Aggregate<List<string>>((x,y) => {
                x.AddRange(y);
                return x;
            });
            var openRules = rules.Where(x => openRuleNames.Contains(x.Key)).Select(x => x.Value).ToHashSet();
            List<string> outStr = new();
            while (!end)
            {
                end = true;
                foreach(var oRule in openRules)
                {
                    foreach (var r in oRule)
                    {
                        if (r.compare(chosen_facts.ToList()))
                        {
                            chosen_facts.Add(r.conseq);
                            outStr.Add(r.ToString());
                            if (r.conseq == required)
                            {
                                end = true;
                                was_found = true;
                                break;
                            }
                            end = false;
                        }
                        openRules.Remove(oRule);
                    }
                }
            }
            if (!was_found)
            {
                outputBox.AppendText("����� ����� �� ����������");
                return;
            }
            outputBox.AppendText("�����:");
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
                outputBox.AppendText("���-�� ���� �� �������");
                return;
            };

            var item = ruleBox.SelectedItem.ToString();

            HashSet<string> inventory = chosen_facts;
            HashSet<string> visited = new();
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
                visited.Add(fact);
                factOut.Add($"��������� ���� {fact} \"{facts[fact]}\"");

                var missing_precs = facts_tree[fact];
                if (missing_precs == null)
                {
                    factOut.Add("��� ������ ����� ������ �� ���������, ������ �� ����������� � ���������");
                    can_create = false;
                    break;
                }
                
                var rule = rules[facts_to_rules[fact]];
                factOut.Add($"��� ���� ����� ������� {rule}");

                factOut.Add($"��� ������� ���������� �����: {string.Join(", ",missing_precs)}");

                foreach(var prec in missing_precs)
                {
                    if (inventory.Contains(prec))
                    {
                        factOut.Add($"���� {prec} ���������� � ���������");
                        continue;
                    }
                    if (visited.Contains(prec))
                    {
                        factOut.Add($"���� {prec} \"{facts[prec]}\" ��� ������� ����� (���� ���������)");
                        continue;
                    }
                    s.Push(prec);
                }
                output.Push(factOut);
            }
            if (!can_create)
            {
                outputBox.AppendText("����� ����������");
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
        /// ���������� ������ ������, ������� ����� ��� ���������� �������, ������������� ��������������� ����
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