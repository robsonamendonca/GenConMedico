using FluentValidation;
using GenConMedico.Models.Contexts;
using GenConMedico.ViewModels.Pacientes;

namespace GenConMedico.Validators.Pacientes
{
    public class AdicionarPacienteValidator : AbstractValidator<AdicionarViewModel>
    {
        public AdicionarPacienteValidator(GenConMed context)
        {
            RuleFor(x => x.CPF)
            .NotEmpty()
               .WithMessage("Campo obrigatório")
            .MaximumLength(11)
               .WithMessage("O CPF deve ter até {MaxLength} caracteres.")
            .Must(cpf => !context.Pacientes.Any(m => m.CPF == cpf))
               .WithMessage("Este CPF já esta em uso.");

            RuleFor(x => x.Nome)
            .NotEmpty()
               .WithMessage("Campo obrigatório")
            .MaximumLength(100)
               .WithMessage("O Nome deve ter até {MaxLength} caracteres.")
            ;

        }

    }
}