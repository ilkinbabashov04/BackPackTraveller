using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class TravelValidator : AbstractValidator<Travel>
    {
        public TravelValidator()
        {
            RuleFor(p => p.Title).MinimumLength(3).WithMessage("Title must be minimum 3 charachter");
            RuleFor(p => p.Description).MinimumLength(3).WithMessage("Description must be minimum 3 charachter");
        }
    }
}
