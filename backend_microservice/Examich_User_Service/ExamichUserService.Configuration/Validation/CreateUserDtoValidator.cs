using Examich.DTO;
using FluentValidation;

namespace Examich.Configuration.Validation
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password needed.")
                .MinimumLength(6)
                .WithMessage("Passowrd does not meet password requirements: \n\n\t Minimal 6 characters\n\tMax 12 characters");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email needed.")
                .EmailAddress()
                .WithMessage("Email invalid.");
        }
    }
}
