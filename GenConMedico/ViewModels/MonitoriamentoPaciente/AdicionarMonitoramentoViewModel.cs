using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenConMedico.ViewModels.MonitoriamentoPaciente
{
    public class AdicionarMonitoramentoViewModel
    {
        [Display(Name = "Pressão Arterial")]
        public string PressaoArterial { get; set; } = string.Empty;
        [Display(Name = "Temperatura")]
        public decimal Temperatura { get; set; } = 0;
        [Display(Name = "Saturação de Oxigêncio")]
        public int SaturacaoOxigenio { get; set; } = 0;
        [Display(Name = "Frequencia Cardiaca")]
        public int FrequenciaCardiaca { get; set; } = 0;
        [Display(Name = "Data de Aferição")]
        public DateTime DataAfericao { get; set; } = DateTime.Now;
    }
}