using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad Soyad Alanı Boş Geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Ad Soyad Alanı Boş Geçilemez");
            //RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Ad Soyad Alanı Boş Geçilemez");
            //RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Ad Soyad Alanı Boş Geçilemez");
            //RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Ad Soyad Alanı Boş Geçilemez");
            //RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Minimum 2 Karakter Giriniz");
            //RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Max 50 Karakter Giriniz");
            //RuleFor(x => x.WriterMail).MinimumLength(15).WithMessage("Minimum 15 Karakter Giriniz");
            //RuleFor(x => x.WriterMail).MaximumLength(200).WithMessage("Max 200 Karakter Giriniz");
        }
    }
}
