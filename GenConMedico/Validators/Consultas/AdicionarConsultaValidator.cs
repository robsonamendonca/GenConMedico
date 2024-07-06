using FluentValidation;
using GenConMedico.ViewModels.Consultas;

namespace GenConMedico.Validators.Consultas
{
    public class AdicionarConsultaValidator : AbstractValidator<AdicionarConsultaViewModel>
    {
        public AdicionarConsultaValidator()
        {
            RuleFor(x => x.Data).NotEmpty().WithMessage("Campo obrigatório")
                                .Must(data => data >= DateTime.Today).WithMessage("A data não pode ser anterior ao dia atual.");

            RuleFor(x => x.Tipo).NotNull().WithMessage("Campo obrigatório");
            
            RuleFor(x => x.IdPaciente).NotEmpty().WithMessage("Campo obrigatório");
            
            RuleFor(x => x.IdMedico).NotEmpty().WithMessage("Campo obrigatório");
        }
    }
}