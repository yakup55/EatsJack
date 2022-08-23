using EntityLayers.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class RegisterChefsValidation : AbstractValidator<Chefs>
    {
        public RegisterChefsValidation()
        {
            RuleFor(x=>x.ChefsName).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x=>x.ChefsMail).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x=>x.ChefsMail).EmailAddress().WithMessage("Geçerli Mail Adresi Giriniz").When(x=>!string.IsNullOrEmpty(x.ChefsMail));
            RuleFor(x=>x.ChefsAbout).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x=>x.ChefsAbout).MinimumLength(50).WithMessage("En az 50 karakter olmalı");
            RuleFor(x=>x.ChefsAbout).MaximumLength(200).WithMessage("En fazla 200 karakter olmalı");
            RuleFor(x=>x.ChefsImage).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x=>x.ChefsPassword).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x=>x.ChefsPassword).MinimumLength(6).WithMessage("En az 6 karakter içermeli");
            RuleFor(x=>x.MedidLinkedin).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x=>x.MedidInstagram).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(x=>x.MedidFacebook).NotEmpty().WithMessage("Boş Olamaz");
        }
    }
}
