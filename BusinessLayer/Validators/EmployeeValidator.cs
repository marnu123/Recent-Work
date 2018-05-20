using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class EmployeeValidator : IValidator<Employee>
    {
        public IEnumerable<string> BrokenRules(Employee entity)
        {
            IEnumerable<string> personRules;
            (entity as Person).Validate(out personRules);
            foreach (string str in personRules) yield return str;
            if (Utils.IsZeroOrEmpty(entity.FK_EmployeeTypeId)) yield return "An employee type must be specified";
            if (Utils.IsEmpty(entity.Password)) yield return "Password field may not be empty";
        }

        public bool IsValid(Employee entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
