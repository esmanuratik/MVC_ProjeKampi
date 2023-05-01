﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class Category_Validatior:AbstractValidator<Category>
    {
        public Category_Validatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("İsim Boş Geçilemez!!!");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez!!!");
            RuleFor(x=>x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız...");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın...");
        }

    }
}
