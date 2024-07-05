using FluentValidation;
using FluentValidation.AspNetCore;
using GenConMedico.Models.Contexts;
using GenConMedico.Models.Entities;
using GenConMedico.ViewModels.Medicos;
using Microsoft.AspNetCore.Mvc;

namespace GenConMedico.Controllers;

public class MedicosController : Controller
{

    private readonly GenConMed _context;

    private readonly IValidator<AdicionarViewModel> _adicionarViewModelValidator;

    private const int TAMANHO_PAGINA = 5;

    public MedicosController(GenConMed context, IValidator<AdicionarViewModel> adicionarViewModelValidator)    
    {
        _context = context;
        _adicionarViewModelValidator = adicionarViewModelValidator;
    }


    public IActionResult Index(string filtro, int pagina = 1){
        decimal paginasTotal = 0;
        var medicos = _context.Medicos.Where(c => c.Nome.Contains(filtro)
        || c.CRM.Contains(filtro))        
        .Select(x => new ListarMedicoViewModel
        {
            Id = x.Id,            
            CRM = x.CRM,
            Nome = x.Nome,
        });
        paginasTotal =(decimal) Math.Ceiling((double)medicos.Count()/TAMANHO_PAGINA);

        ViewBag.Filtro = filtro;
        ViewBag.NumeroPagina = pagina;
        ViewBag.TotalPaginas = paginasTotal >0 ? paginasTotal : 1 ;

        return View(medicos.Skip((pagina-1) * TAMANHO_PAGINA).Take(TAMANHO_PAGINA));
    }

    public IActionResult Adicionar(){
        
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Adicionar(AdicionarViewModel dados){

        var validacao = _adicionarViewModelValidator.Validate(dados);

        if(!validacao.IsValid){
            validacao.AddToModelState(ModelState,string.Empty);
            return View(dados);
        }
        
        var medico = new Medico {
            CRM = dados.CRM,
            Nome= dados.Nome,
        };

        _context.Medicos.Add(medico);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Editar(int Id){

        return View();
    }
}
