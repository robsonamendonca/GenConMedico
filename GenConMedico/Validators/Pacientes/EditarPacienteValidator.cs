using System.Text.RegularExpressions;
using FluentValidation;
using GenConMedico.Models.Contexts;
using GenConMedico.ViewModels.Pacientes;

namespace GenConMedico.Validators.Pacientes
{
   public class EditarPacienteValidator : AbstractValidator<EditarViewModal>
   {
      public EditarPacienteValidator(GenConMed context)
      {
         RuleFor(x => x.CPF)
         .NotEmpty()
            .WithMessage("Campo obrigatório")
         .Must(cpf => Regex.Replace(cpf, "[^0-9]", "").Length == 11)
            .WithMessage("O CPF deve ter até 11 caracteres.");

         RuleFor(x => x.Nome)
         .NotEmpty()
            .WithMessage("Campo obrigatório")
         .MaximumLength(100)
            .WithMessage("O nome deve ter até {MaxLength} caracteres.")
         ;

         RuleFor(x => x.DataNascimento)
         .NotEmpty()
            .WithMessage("Campo obrigatório")
         .Must(data => data <= DateTime.Today)
            .WithMessage("A data de nascimento não pode ser futura.")
         ;


         RuleFor(x => x).Must(x => !context.Pacientes.Any(m => m.CPF == x.CPF && m.Id != x.Id))
            .WithMessage("Este CPF já esta em uso.");


      }
   }
}