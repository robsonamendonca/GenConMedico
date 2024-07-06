namespace GenConMedico.ViewModels.MonitoriamentoPaciente
{
    public class ListarMonitoramentoViewModal
    {
        public int Id { get; set; }
        public string PressaoArterial { get; set; } = string.Empty;

        public decimal Temperatura { get; set; } = 0;

        public int SaturacaoOxigenio { get; set; } = 0;

        public int FrequenciaCardiaca { get; set; } = 0;

        public DateTime DataAfericao { get; set; } = DateTime.Now;
    }
}