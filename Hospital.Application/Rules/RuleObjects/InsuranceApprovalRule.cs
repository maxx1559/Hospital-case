using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules.RuleObjects
{
    public class InsuranceApprovalRule : IRule
    {
        public string Name => "Insurance Approval Rule";
        public string ErrorMessage => "[ERROR] This department requires valid insurance approval.";

        public async Task<bool> RulesSatisfied(Appointment appointment, CancellationToken token)
        {
            bool needsApproval = appointment.Department == "Physiotherapy";
            bool hasApproval = true; // Placeholder for actual check logic
            return await Task.FromResult(needsApproval && hasApproval);
        }
    }
}
