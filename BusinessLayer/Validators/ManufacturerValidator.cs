using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class ManufacturerValidator : IValidator<Manufacturer>
    {
        public IEnumerable<string> BrokenRules(Manufacturer entity)
        {
            if (Utils.IsEmpty(entity.Name)) yield return "Manufacturer name may not be empty";
        }

        public bool IsValid(Manufacturer entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
