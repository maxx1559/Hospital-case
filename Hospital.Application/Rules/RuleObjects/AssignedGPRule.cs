using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules.RuleObjects
{
    public class AssignedGPRule : IRule
    {
        public string Name => "Assigned GP Rule";
        public string ErrorMessage => "[ERROR] Patients can only book appointments with their assigned GP.";

        public async Task<bool> RulesSatisfied(Appointment appointment, CancellationToken token)
        {
            bool assignedGP = true; // Placeholder for actual check logic
            return await Task.FromResult(assignedGP);
        }
    }
}
