using EntityLayers.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.ContactMail).EmailAddress().WithMessage("Geçerli Mail Adresi Giriniz").When(x=>!string.IsNullOrEmpty(x.ContactMail));
            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.ContactMessage).MinimumLength(20).WithMessage("En az 20 karakter içermeli");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.ContactSubject).MinimumLength(5).WithMessage("En az 5 karakter içermeli");
        }
    }
}
