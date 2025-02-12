using System.ComponentModel.DataAnnotations;
using GenConMedico.Models.Enums;

namespace GenConMedico.ViewModels.Consultas
{
    public class AdicionarConsultaViewModel
    {
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public TipoConsulta Tipo { get; set; }
        [Display(Name = "Paciente")]
        public int IdPaciente { get; set; }
        [Display(Name = "Médico")]
        public int IdMedico { get; set; }
    }
}