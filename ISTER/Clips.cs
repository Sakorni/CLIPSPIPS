using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CLIPSNET;

namespace ISTER
{
    internal class Clips
    {
        private CLIPSNET.Environment clips;
        private string clpFile;
        public Clips(string clpFile)
        {
            this.clips = new();
            this.clpFile = clpFile;
            loadFromFile(clpFile);
        }
        public void loadFromFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string str = sr.ReadToEnd();
                this.clips.LoadFromString(str);
            }
        }
        public void pushFact(string fact)
        {
            clips.Eval($"(assert (item (id {fact})))");
        }
        public void clear()
        {
            clips.Clear();
            loadFromFile(clpFile);
        }
        public void run()
        {
            clips.Run();
        }
        public Dictionary<string, List<string>> getFactVals()
        {
            Dictionary<string, List<string>> res = new();
            var lfi = clips.GetFactList();
            res["item"] = new List<string>();
            res["precept"] = new List<string>();
            foreach (var f in lfi)
            {
                res[f.RelationName].Add(f.GetSlotValues()[0].Contents);
            }
            return res;
        }
        public static void parseRules(string inFile, string outFile)
        {
            using(StreamReader sr = new StreamReader(inFile))
            {
                FileStream fs = File.OpenWrite(outFile);
                fs.SetLength(0);
                fs.Close();
                using(StreamWriter sw = new StreamWriter(outFile, true))
                {
                    List<string> parseDels = new List<string> { ":", "->", "#" };
                    sw.WriteLine("(deftemplate item\n" +
                        "\t(slot id)\n)\n");
                    sw.WriteLine("(deftemplate precept\n" +
                        "\t(slot id)\n)\n");
                    while (!sr.EndOfStream)
                    {
                        var str = sr.ReadLine()!;

                        List<string> args = new();
                        int from = 0;
                        int to = 0;
                        foreach (var del in parseDels)
                        {
                            to = str.IndexOf(del) - from;
                            args.Add(str.Substring(from, to));
                            to += del.Length;
                            from = from + to;
                        }
                        args.Add(str.Substring(from));
                        args[2] = args[2].Trim();

                        var precs = Regex.Replace(args[1], @"\s+", "").Split(",");

                        string outStr = $"(defrule {args[0]}\n";
                        foreach(var prec in precs)
                        {
                            outStr += $"\t(item (id {prec}))\n";
                        }
                        outStr += "\t=>\n";
                        outStr += $"\t(assert (item (id {args[2]})))\n";
                        outStr += $"\t(assert (precept (id {args[0]})))\n";
                        outStr += ")\n";
                        sw.WriteLine(outStr);
                    }
                }
            }
        }
    }
}
