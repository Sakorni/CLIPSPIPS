namespace ISTER
{
    public partial class Form1 : Form
    {
        public static SortedDictionary<string, string> facts = new();
        private static Dictionary<string, Rule> rules = new();
        CLIPSNET.Environment clips = new();

        public Form1()
        {
            InitializeComponent();
            facts = Get_facts("facts.txt");
            rules = Get_rules("rules.txt");

        }

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
                }
                catch { }
            }
            return res;
        }

        internal static Dictionary<string, Rule> Rule { get => rule; set => rule = value; }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}