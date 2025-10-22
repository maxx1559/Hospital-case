using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules.RuleObjects
{
    public class UnknownDepartmentRule : IRule
    {
        public string Name => "Unknown Department Rule";
        public string ErrorMessage => "[ERROR] The specified department is unknown or unsupported.";
        public async Task<bool> RulesSatisfied(Appointment appointment, CancellationToken token)
        {
            bool isKnownDepartment = false; // Placeholder for actual check logic
            return await Task.FromResult(isKnownDepartment);
        }
    }
}
