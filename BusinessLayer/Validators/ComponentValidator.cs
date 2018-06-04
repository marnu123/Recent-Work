using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using static BusinessLayer.Utils;

namespace BusinessLayer.Validators
{
    public class ComponentValidator : IValidator<Component>
    {
        public IEnumerable<string> BrokenRules(Component entity)
        {
            if (IsEmpty(entity.Id)) yield return "A component ID has to be specified";
            if (IsEmpty(entity.Title)) yield return "Component title may not be empty";
        }

        public bool IsValid(Component entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
