using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class NotificationTypeValidator : IValidator<NotificationType>
    {
        public IEnumerable<string> BrokenRules(NotificationType entity)
        {
            if (!Utils.IsEmpty(entity.Title) && !isUniqueTitle(entity.Title)) yield return "Notification Type already exists";
        }

        private bool isUniqueTitle(string title)
        {
            return NotificationType.Select(e => e.Title == title).Count == 0;
        }

        public bool IsValid(NotificationType entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
