﻿using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adini Bos Gecemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Aciklamayi Bos Gecemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lutfen En Az 3 Karakter Girisi Yapiniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lutfen 20 Karakterden Fazla Deger Girisi Yapmayiniz");
        }
    }
}
