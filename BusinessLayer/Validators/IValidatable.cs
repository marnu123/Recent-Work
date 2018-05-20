using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public interface IValidatable<T>
    {
        bool Validate(IValidator<T> validator, out IEnumerable<string> brokenRules);
    }
}
