using ApplicationCore.DTOs;
using ApplicationCore.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Validators
{
	public class OrderDtoValidator : AbstractValidator<OrderDto>
	{
		public OrderDtoValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Введіть ім'я отримувача")
				.Matches(@"^[A-Я].*").WithMessage("Ім'я отримувача має починатися з великої букви")
			    .Length(3, 60).WithMessage("Ім'я отримувача має містити від 10 до 60 символів");
			RuleFor(x => x.Surname)
				.NotEmpty().WithMessage("Введіть прізвище отримувача")
				.Matches(@"^[A-Я].*").WithMessage("Прізвище отримувача має починатися з великої букви")
				.Length(3, 60).WithMessage("Прізвище отримувача має містити від 10 до 60 символів");
			RuleFor(x => x.SecondName)
				.NotEmpty().WithMessage("Ім'я по батькові не може бути пустим")
				.Matches(@"^[A-Я].*").WithMessage("Ім'я по батькові отримувача має починатися з великої букви")
				.Length(3, 60).WithMessage("Ім'я по батькові отримувача має містити від 10 до 60 символів");
			RuleFor(x => x.Branch)
				.NotEmpty().WithMessage("Введіть адрес відділення")
				.Length(10, 2000).WithMessage("Адрес відділення має містити від 5 до 100 символів");
			RuleFor(x => x.Branch)
				.NotEmpty().WithMessage("Введіть адрес відділення")
				.Length(10, 2000).WithMessage("Адрес відділення має містити від 5 до 100 символів");
			RuleFor(x => x.CityId)
			   .NotEmpty().WithMessage("Miсто не обране");
			RuleFor(x => x.Postal)
			   .NotEmpty().WithMessage("Курьєр не обраний");
		}
	}
}
