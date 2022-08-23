using EntityLayers.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ServiceValidation : AbstractValidator<Service>
    {
        public ServiceValidation()
        {
            RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.ServiceName).MinimumLength(5).WithMessage("En az 5 karakter içermeli");
            RuleFor(x => x.ServiceContents).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x => x.ServiceContents).MinimumLength(10).WithMessage("En az 10 karakter içermeli");
        }
    }
}
