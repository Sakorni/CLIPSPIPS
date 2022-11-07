using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISTER
{
    internal class Rule
    {
        public string Name { get; set; }
        public List<string> preconds { get; set; }
        public string conseq { get; set; }
        public string readable_form { get; set; }

        public Rule(string raw_rule)
        {
            Regex regex = new Regex(@"^(r\d+): (.*) -> (\w+\d+) # (.*)$");
            var match = regex.Match(raw_rule);
            Name = match.Groups[1].Value;
            preconds = match.Groups[2].Value.Split(", ").ToList();
            conseq = match.Groups[3].Value;
            readable_form = match.Groups[4].Value;
        }
        public override string ToString()
        {
            return $"{Name}: {String.Join(", ", preconds.ToArray())} -> {conseq} ({readable_form})";
        }

        /// <summary>
        /// Проверяет, что все посылки правила присутствуют в списке заданных фактов
        /// </summary>
        public bool compare(List<string> currentFacts)
        {
            return preconds.All(fact => currentFacts.Contains(fact));
        }
    }
}
