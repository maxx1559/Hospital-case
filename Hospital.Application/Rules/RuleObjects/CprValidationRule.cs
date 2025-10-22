using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules.RuleObjects
{
    public class CprValidationRule : IRule
    {
        private NationalRegistryService nationalRegistryService;

        public CprValidationRule(NationalRegistryService nationalRegistryService)
        {
            this.nationalRegistryService = nationalRegistryService;
        }
        public string Name => "Cpr Validation Approval Rule";
        public string ErrorMessage => "[ERROR] Invalid CPR number. Cannot schedule appointment.";

        public async Task<bool> RulesSatisfied(Appointment appointment, CancellationToken token)
        {
            
            return await nationalRegistryService.ValidateCpr(appointment.Cpr);
        }
    }
}
