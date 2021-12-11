using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adini Bos Gecemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadini Bos Gecemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Başlık Kısmını Bos Gecemezsiniz");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkımda kısmında en az bir a harfi gecmelidir.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Kısmını Bos Gecemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Soyadini Bos Gecemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lutfen En Az 2 Karakter Girisi Yapiniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lutfen 50 Karakterden Fazla Deger Girisi Yapmayiniz");
        }
    }
}
