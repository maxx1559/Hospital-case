using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class DepartmentRuleAttribute : Attribute
    {
        public IEnumerable<string> Departments { get; }
        public DepartmentRuleAttribute(params string[] departments)
        {
            Departments = departments ?? Array.Empty<string>();
        }
    }
}
