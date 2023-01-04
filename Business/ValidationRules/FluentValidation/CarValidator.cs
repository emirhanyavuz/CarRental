using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description.Length).GreaterThanOrEqualTo(3);
            RuleFor(c => c.DailyPrice).GreaterThan(20);
            RuleFor(c => Convert.ToInt32(c.ModelYear)).GreaterThanOrEqualTo(1990);
            RuleFor(c => c.DailyPrice).GreaterThan(150).When(c => c.BrandId == 2);
            RuleFor(c => c.Description).Must(StartsWithM).WithMessage("Arabalar M harfi ile başlamalı!");

        }

        private bool StartsWithM(string arg)
        {
            return arg.StartsWith("M");
        }
    }
}
