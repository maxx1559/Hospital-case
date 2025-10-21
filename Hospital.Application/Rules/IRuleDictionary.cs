using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules
{
    public interface IRuleDictionary
    {
        //Factory for rules based on department
        IEnumerable<IRule> GetRulesForDepartment(string department);
    }
}
