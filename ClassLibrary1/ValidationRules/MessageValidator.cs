using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Bos Gecemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Bos Gecemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Bos Gecemezsiniz");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Lutfen Gecerli Bir Mail Adresi Giriniz ");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lutfen En Az 3 Karakter Girisi Yapiniz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lutfen En Az 100 Karakter Girisi Yapiniz");
        }       
    }
}
