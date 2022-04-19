using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation_Rules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Yazar adı boş olamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Yazar soyadı boş olamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Unvan alanı boş olamaz");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Lütfen en az 2 karakter girin");
            RuleFor(x => x.LastName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girin");
        }
    
    }
}
