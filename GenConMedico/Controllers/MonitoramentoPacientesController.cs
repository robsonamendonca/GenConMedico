using GenConMedico.Models.Contexts;
using GenConMedico.ViewModels.MonitoriamentoPaciente;
using Microsoft.AspNetCore.Mvc;

namespace GenConMedico.Controllers
{
    [Route("monitoramento")]
    public class MonitoramentoPacientesController : Controller
    {

        private readonly GenConMed _context;

        public MonitoramentoPacientesController(GenConMed context)
        {
            _context = context;
        }

        public IActionResult Index(int idPaciente)
        {

            ViewBag.IdPaciente = idPaciente;  
            var monitoramentos = _context.MonitoramentoPaciente
                                 .Where(x => x.IdPaciente == idPaciente)
                                 .Select(x => new ListarMonitoramentoViewModal{
                                    Id = x.Id,
                                    PressaoArterial = x.PressaoArterial,
                                    SaturacaoOxigenio = x.SaturacaoOxigenio,
                                    Temperatura = x.Temperatura,
                                    FrequenciaCardiaca = x.FrequenciaCardiaca,
                                    DataAfericao = x.DataAfericao
                                 });

            return View(monitoramentos);
        }


        [Route("Adicionar")]
        public IActionResult Adicionar(int idPaciente){
            return View();
        }

    }
}