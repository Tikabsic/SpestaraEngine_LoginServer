using FluentValidation;
using DatabaseIntegration.Database;
using Services.DTO;

namespace Services.Validator
{

    internal class AccountRegistrationValidator : AbstractValidator<RegisterRequest>
    {
        public AccountRegistrationValidator()
        {
            RuleFor(a => a.ConfirmationPassword)
                .Equal(a => a.Password);

            RuleFor(a => a.Password)
                .MinimumLength(6)
                .MaximumLength(24);

            RuleFor(a => a.AccountName)
                .MinimumLength(5)
                .MaximumLength(16);

            RuleFor(a => a.Email)
                .EmailAddress();
        }
    }
}
