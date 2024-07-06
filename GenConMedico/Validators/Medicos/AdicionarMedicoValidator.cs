using FluentValidation;
using GenConMedico.Models.Contexts;
using GenConMedico.ViewModels.Medicos;

namespace GenConMedico.Validators.Medicos
{
    public class AdicionarMedicoValidator : AbstractValidator<AdicionarMedicoViewModel>
    {
        public AdicionarMedicoValidator(GenConMedContext context)
        {
            RuleFor(x => x.CRM).NotEmpty().WithMessage("Campo obrigatório.")
                               .MaximumLength(20).WithMessage("O CRM deve ter até {MaxLength} caracteres.")
                               .Must(crm => !context.Medicos.Any(m => m.CRM == crm)).WithMessage("Este CRM já está em uso.");

            RuleFor(x => x.Nome).NotEmpty().WithMessage("Campo obrigatório.")
                                .MaximumLength(200).WithMessage("O CRM deve ter até {MaxLength} caracteres.");
        }
    }
}