using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules.RuleObjects
{
    public class FinancialApprovalRule : IRule
    {
        public string Name => "Financial Approval Rule";
        public string ErrorMessage => "[ERROR] This department may require financial approval.";

        public async Task<bool> RulesSatisfied(Appointment appointment, CancellationToken token)
        {
            bool needsApproval = appointment.Department == "Radiology";
            bool hasApproval = true; // Placeholder for actual check logic
            return await Task.FromResult(needsApproval && hasApproval);
        }
    }
}
