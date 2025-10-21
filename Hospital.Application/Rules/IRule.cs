using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules
{
    public interface IRule
    {
        string Name { get;}
        Task<bool> RulesSatisfied(Appointment appointment, CancellationToken token);
        string ErrorMessage { get; }

    }
}
