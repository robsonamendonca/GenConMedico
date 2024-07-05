using System.IO.Pipelines;
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
    private readonly IValidator<EditarViewModal> _editarViewModelValidator;

    private const int TAMANHO_PAGINA = 5;

    public MedicosController(GenConMed context
    , IValidator<AdicionarViewModel> adicionarViewModelValidator
    , IValidator<EditarViewModal> editarViewModelValidator)
    {
        _context = context;
        _adicionarViewModelValidator = adicionarViewModelValidator;
        _editarViewModelValidator = editarViewModelValidator;
    }


    public IActionResult Index(string filtro, int pagina = 1)
    {
        decimal paginasTotal = 0;
        var medicos = _context.Medicos.Where(c => c.Nome.Contains(filtro)
        || c.CRM.Contains(filtro))
        .Select(x => new ListarMedicoViewModel
        {
            Id = x.Id,
            CRM = x.CRM,
            Nome = x.Nome,
        });
        paginasTotal = (decimal)Math.Ceiling((double)medicos.Count() / TAMANHO_PAGINA);

        ViewBag.Filtro = filtro;
        ViewBag.NumeroPagina = pagina;
        ViewBag.TotalPaginas = paginasTotal > 0 ? paginasTotal : 1;

        return View(medicos.Skip((pagina - 1) * TAMANHO_PAGINA).Take(TAMANHO_PAGINA));
    }

    public IActionResult Adicionar()
    {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Adicionar(AdicionarViewModel dados)
    {

        var validacao = _adicionarViewModelValidator.Validate(dados);

        if (!validacao.IsValid)
        {
            validacao.AddToModelState(ModelState, string.Empty);
            return View(dados);
        }

        var medico = new Medico
        {
            CRM = dados.CRM,
            Nome = dados.Nome,
        };

        _context.Medicos.Add(medico);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Editar(int Id)
    {

        var medico = _context.Medicos.Find(Id);
        if (medico != null)
        {
            return View(new EditarViewModal
            {
                Id = medico.Id,
                CRM = medico.CRM,
                Nome = medico.Nome
            });
        }
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Editar(int Id, EditarViewModal editarViewModal)
    {
        var validacao = _editarViewModelValidator.Validate(editarViewModal);

        if (!validacao.IsValid)
        {
            validacao.AddToModelState(ModelState, string.Empty);
            return View(editarViewModal);
        }

        var medico = _context.Medicos.Find(Id);
        if (medico != null)
        {
            medico.CRM = editarViewModal.CRM;
            medico.Nome = editarViewModal.Nome;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

    public IActionResult Excluir(int Id)
    {
        var medico = _context.Medicos.Find(Id);
        if (medico != null)
        {
            return View(new ListarMedicoViewModel
            {
                Id = medico.Id,
                CRM = medico.CRM,
                Nome = medico.Nome
            });
        }
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Excluir(int Id, ListarMedicoViewModel dados)
    {
        var medico = _context.Medicos.Find(Id);
        if (medico != null)
        {
            _context.Remove(medico);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

}