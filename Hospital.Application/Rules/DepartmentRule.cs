using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Rules
{
    public class DepartmentRule
    {
        public IEnumerable<string> Departments { get; }
        public DepartmentRule(IEnumerable<string> departments)
        {
            Departments = departments;
        }
    }
}
