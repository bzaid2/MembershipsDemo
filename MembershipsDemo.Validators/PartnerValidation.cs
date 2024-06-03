using FluentValidation;

namespace MembershipsDemo.Validators
{
    public class PartnerValidation : AbstractValidator<Models.Partner>
    {
        public PartnerValidation()
        {
            RuleFor(c => c.Gender)
                .NotNull()
                .WithName("Género");

            RuleFor(c => c.Email)
                .EmailAddress()
                .When(c => !string.IsNullOrEmpty(c.Email))
                .WithName("Correo eletrónico");

            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Nombre(s)");

            RuleFor(c => c.LastName)
                .MinimumLength(3)
                .When(c => !string.IsNullOrEmpty(c.LastName))
                .WithName("Apellido(s)");

            RuleFor(c => c.Phone)
                .MinimumLength(10)
                .When(c => !string.IsNullOrEmpty(c.Phone))
                .WithName("Número celular");
        }
    }
}
