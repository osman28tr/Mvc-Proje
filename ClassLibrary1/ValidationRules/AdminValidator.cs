using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ValidationRules
{
    public class AdminValidator: AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Admin Kullanıcı Adını Bos Gecemezsiniz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifreyi Bos Gecemezsiniz");
            RuleFor(x => x.AdminUserName).MinimumLength(3).WithMessage("Lutfen En Az 3 Karakter Girisi Yapiniz");
            RuleFor(x => x.AdminUserName).MaximumLength(20).WithMessage("Lutfen 20 Karakterden Fazla Deger Girisi Yapmayiniz");
        }     
    }
}
