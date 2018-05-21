using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class LocationValidator : IValidator<Location>
    {
        public IEnumerable<string> BrokenRules(Location entity)
        {
            if (Utils.IsEmpty(entity.HouseNumber)) yield return "A House Number must be specified";
            IEnumerable<string> brokenRules;
            if (!entity.Street.Validate(out brokenRules))
                foreach (string str in brokenRules) yield return str;

            if (!entity.Street.City.Validate(out brokenRules))
                foreach (string str in brokenRules) yield return str;
        }

        public bool IsValid(Location entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
