using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class CityValidator : IValidator<City>
    {
        public IEnumerable<string> BrokenRules(City entity)
        {
            if (Utils.IsEmpty(entity.Name)) yield return "City Title may not be empty";
        }

        public bool IsValid(City entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
