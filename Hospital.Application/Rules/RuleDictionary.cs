using Hospital.Application.Rules.RuleObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules
{
    public class RuleDictionary : IRuleDictionary
    {
        private Dictionary<string, List<IRule>> rulesForDepartment;

        public RuleDictionary(Dictionary<string, List<IRule>> rulesForDepartment)
        {
            this.rulesForDepartment = rulesForDepartment;
        }

        public IEnumerable<IRule> GetRulesForDepartment(string department)
        {
            IEnumerable<IRule> rules = rulesForDepartment.TryGetValue(department, out var foundRules) ? foundRules : new List<IRule>() { new UnknownDepartmentRule() };


            return rules;
        }


    }
}
