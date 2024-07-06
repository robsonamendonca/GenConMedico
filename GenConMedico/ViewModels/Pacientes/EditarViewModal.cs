using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenConMedico.ViewModels.Pacientes
{
    public class EditarViewModal
    {
        public int Id { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

    }
}