using ApplicationCore.Models;
using FluentValidation;

namespace ApplicationCore.Validators
{
	public class AdvertModelValidator : AbstractValidator<AdvertModel>
	{
		public AdvertModelValidator()
		{
			RuleFor(x => x.Description)
				.NotEmpty().WithMessage("Опис  не може бути пустим")
				.Length(10, 2000).WithMessage("Опис має містити від 10 до 2000 символів");
			RuleFor(x => x.Price)
				.NotEmpty().WithMessage("Ціна не може бути пустою")
				.GreaterThanOrEqualTo(0)
				.WithMessage("Ціна не може менше нуля");
			RuleFor(x => x.Title)
				.NotEmpty().WithMessage("Заголовок не може бути пустим")
				.Length(10, 200).WithMessage("Заголовок має містити від 10 до 200 символів");
			//RuleFor(x => x.UserId).Empty().NotEmpty().Null().NotNull();
				//.NotEmpty().WithMessage("Ім'я не може бути пустим")
				//.Matches(@"^[A-Z А-Я].*").WithMessage("Ім'я повинно починатися з великої букви")
				//.Length(2, 60).WithMessage("Ім'я має містити від 2 до 60 символів");
			RuleFor(x => x.CategoryId)
			   .NotEmpty().WithMessage("Категорія не обрана");
			RuleFor(x => x.CityId)
			   .NotEmpty().WithMessage("Miсто не обране");
		}
	}
}
