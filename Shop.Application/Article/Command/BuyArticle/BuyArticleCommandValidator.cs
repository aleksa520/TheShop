using FluentValidation;

namespace Shop.Application.Article.Command.BuyArticle;

public class BuyArticleCommandValidator : AbstractValidator<BuyArticleCommand>
{
	public BuyArticleCommandValidator()
	{
		RuleFor(a => a).NotNull();
		RuleFor(a => a.Name).NotEmpty();
		RuleFor(a => a.Price).GreaterThan(0);
    }
}
