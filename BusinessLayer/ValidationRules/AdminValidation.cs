using EntityLayers.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidation : AbstractValidator<Admin>
    {
        public AdminValidation()
        {
            RuleFor(x => x.AdminName).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.AdminPassword).MinimumLength(6).WithMessage("En az 6 karakter içermeli");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Boş Olamaz");
        }
    }
}
