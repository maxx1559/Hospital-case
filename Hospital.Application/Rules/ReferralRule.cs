using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules
{

    public class ReferralRule : IRule
    {
        public string Name => "Referral Rule";
        public string ErrorMessage => "[ERROR] This department requires a doctor's referral.";

        public async Task<bool> RulesSatisfied(Appointment appointment, CancellationToken token)
        {
            bool hasReferral = true; // Placeholder for actual referral check logic
            return await Task.FromResult(hasReferral);
        }
    }
}
