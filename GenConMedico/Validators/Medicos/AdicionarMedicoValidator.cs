using FluentValidation;
using GenConMedico.Models.Contexts;
using GenConMedico.ViewModels.Medicos;

namespace GenConMedico.Validators.Medicos;

public class AdicionarMedicoValidator : AbstractValidator<AdicionarViewModel>
{
    public AdicionarMedicoValidator(GenConMed context)
    {
        RuleFor(x => x.CRM)
        .NotEmpty()
           .WithMessage("Campo obrigatório")
        .MaximumLength(20)
           .WithMessage("O CRM deve ter até {MaxLength} caracteres.")
        .Must(crm => !context.Medicos.Any(m => m.CRM == crm))
           .WithMessage("Este CRM já sta em uso.");

        RuleFor(x => x.Nome)
        .NotEmpty()
           .WithMessage("Campo obrigatório")
        .MaximumLength(100)
           .WithMessage("O Nome deve ter até {MaxLength} caracteres.")
        ;

    }

}
