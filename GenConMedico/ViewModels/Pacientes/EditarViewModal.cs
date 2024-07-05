using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenConMedico.ViewModels.Pacientes
{
    public class EditarViewModal
    {
        public int Id { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
    }
}