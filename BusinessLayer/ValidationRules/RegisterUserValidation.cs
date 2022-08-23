using EntityLayers.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class RegisterUserValidation : AbstractValidator<Register>
    {
        public RegisterUserValidation()
        {
            RuleFor(x => x.RegisterMail).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.RegisterPassword).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.RegisterPassword).MinimumLength(6).WithMessage("En az 6 karakter içermeli");
            RuleFor(x => x.RegisterPasswordAgain).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.RegisterMail).EmailAddress().WithMessage("Geçerli Mail adresi giriniz").When(x => !string.IsNullOrEmpty(x.RegisterMail));
            RuleFor(x => x.RegisterPassword).Equal(x => x.RegisterPasswordAgain).WithMessage("Şifreler Eşleşmiyor");
        }
    }
}
