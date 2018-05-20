using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public static class Validator
    {
        public static bool Validate<T>(this T entity, out IEnumerable<string> brokenRules)
            where T : IValidatable<T>
        {
            return entity.Validate(ValidatorFactory.GetValidator<T>(), out brokenRules);
        }
    }
}
