using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Validators;
using BusinessLayer.Classes;
using static BusinessLayer.Utils;

namespace BusinessLayer.Validators
{
    public class ConfigurationValidator : IValidator<Configuration>
    {
        public IEnumerable<string> BrokenRules(Configuration entity)
        {
            if (IsEmpty(entity.Title)) yield return "Configuration title may not be empty";
            if (IsEmpty(entity.PK_ConfigurationID)) yield return "Configuration ID may not be empty";
            if (IsEmpty(entity.Value)) yield return "Configuration value may not be empty";
        }

        public bool IsValid(Configuration entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
