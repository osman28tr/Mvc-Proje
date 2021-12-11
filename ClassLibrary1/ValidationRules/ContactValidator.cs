using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Bos Gecemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adini Bos Gecemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanici Adini Bos Gecemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lutfen En Az 3 Karakter Girisi Yapiniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lutfen En Az 3 Karakter Girisi Yapiniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lutfen 20 Karakterden Fazla Deger Girisi Yapmayiniz");
        }
    }
}
