using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class StreetValidator : IValidator<Street>
    {
        public IEnumerable<string> BrokenRules(Street entity)
        {
            if (Utils.IsEmpty(entity.Name)) yield return "Street Name may not be empty";
            if (Utils.IsEmpty(entity.AreaCode)) yield return "Street Area Code may not be empty";
            if (Utils.IsZeroOrEmpty(entity.FK_CityID)) yield return "A city must be selected";
        }

        public bool IsUnique(Street entity)
        {
            return Street.Select(s => s.AreaCode == entity.AreaCode && s.FK_CityID == entity.FK_CityID
                && s.Name == entity.Name).Count == 0;
        }

        public bool IsValid(Street entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
