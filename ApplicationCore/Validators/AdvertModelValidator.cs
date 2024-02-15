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
				.Length(10,int.MaxValue).WithMessage("Опис має містити від 10 до 2000 символів");
			RuleFor(x => x.Price)
				.NotEmpty().WithMessage("Ціна не може бути пустою")
				.GreaterThanOrEqualTo(0)
				.WithMessage("Ціна не може менше нуля");
			RuleFor(x => x.Title)
				.NotEmpty().WithMessage("Заголовок не може бути пустим")
				.Length(10, 200).WithMessage("Заголовок має містити від 10 до 200 символів");
			RuleFor(x => x.CategoryId)
			   .NotEmpty().WithMessage("Категорія не обрана");
			RuleFor(x => x.CityId)
			   .NotEmpty().WithMessage("Miсто не обране");

		}
	}
}
