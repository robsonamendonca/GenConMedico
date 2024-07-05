using FluentValidation;
using GenConMedico.Models.Contexts;
using GenConMedico.ViewModels.Medicos;


namespace GenConMedico.Validators.Medicos;


public class EditarMedicoValidator : AbstractValidator<EditarViewModal>
{
    public EditarMedicoValidator(GenConMed context)
    {
        RuleFor(x => x.CRM)
        .NotEmpty()
           .WithMessage("Campo obrigatório")
        .MaximumLength(20)
           .WithMessage("O CRM deve ter até {MaxLength} caracteres.")
        ;

        RuleFor(x => x.Nome)
        .NotEmpty()
           .WithMessage("Campo obrigatório")
        .MaximumLength(100)
           .WithMessage("O Nome deve ter até {MaxLength} caracteres.")
        ;

        RuleFor(x => x).Must(x => !context.Medicos.Any(m => m.CRM == x.CRM && m.Id != x.Id))
           .WithMessage("Este CRM já sta em uso.");

    }

}