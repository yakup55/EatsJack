using EntityLayers.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EatsValidation : AbstractValidator<Eats>
    {
        public EatsValidation()
        {
            RuleFor(x=>x.EatsName).NotEmpty().WithMessage("Yemek Adı Boş olamaz").Length(2,50).WithMessage("Yemek Adı en az 2 En fazla 50 karakter içermeli");
            RuleFor(x=>x.EatsIngredients).NotEmpty().WithMessage("Malzeme Boş olamaz");
            RuleFor(x=>x.EatsImage).NotEmpty().WithMessage("Resim Boş olamaz");
            RuleFor(x=>x.EatsSpecification).MinimumLength(576).WithMessage("Tarif en az 576 karakter olmalı");
            RuleFor(x=>x.EatsIngredients).MinimumLength(50).WithMessage("Malzeme en az 50 karakter olmalı");
        }
    }
}
