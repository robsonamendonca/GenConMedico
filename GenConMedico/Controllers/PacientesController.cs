using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.IO.Pipelines;
using FluentValidation;
using FluentValidation.AspNetCore;
using GenConMedico.Models.Contexts;
using GenConMedico.Models.Entities;
using GenConMedico.ViewModels.Pacientes;
using Microsoft.AspNetCore.Mvc;

namespace GenConPaciente.Controllers;

public class PacientesController : Controller
{

    private readonly GenConMed _context;

    private readonly IValidator<AdicionarViewModel> _adicionarViewModelValidator;
    private readonly IValidator<EditarViewModal> _editarViewModelValidator;

    private const int TAMANHO_PAGINA = 5;

    public PacientesController(GenConMed context
    , IValidator<AdicionarViewModel> adicionarViewModelValidator
    , IValidator<EditarViewModal> editarViewModelValidator
    )
    {
        _context = context;
       _adicionarViewModelValidator = adicionarViewModelValidator;
       _editarViewModelValidator = editarViewModelValidator;
    }


    public IActionResult Index(string filtro, int pagina = 1)
    {
        decimal paginasTotal = 0;
        var Pacientes = _context.Pacientes.Where(c => c.Nome.Contains(filtro)
        || c.CPF.Contains(filtro))
        .Select(x => new ListarPacienteViewModal
        {
            Id = x.Id,
            CPF=x.CPF,
            Nome = x.Nome,
        });
        paginasTotal = (decimal)Math.Ceiling((double)Pacientes.Count() / TAMANHO_PAGINA);

        ViewBag.Filtro = filtro;
        ViewBag.NumeroPagina = pagina;
        ViewBag.TotalPaginas = paginasTotal > 0 ? paginasTotal : 1;

        return View(Pacientes.Skip((pagina - 1) * TAMANHO_PAGINA).Take(TAMANHO_PAGINA));
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

        var paciente = new Paciente
        {
            CPF = Regex.Replace( dados.CPF, "[^0-9]",""),
            Nome = dados.Nome,
            DataNascimento = dados.DataNascimento,
        };

        _context.Pacientes.Add(paciente);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Editar(int Id)
    {

        var paciente = _context.Pacientes.Find(Id);
        if (paciente != null)
        {
            return View(new EditarViewModal
            {
                Id = paciente.Id,
                CPF = paciente.CPF,
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento
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

        var paciente = _context.Pacientes.Find(Id);
        if (paciente != null)
        {
            paciente.CPF = Regex.Replace(editarViewModal.CPF, "[^0-9]","");
            paciente.Nome = editarViewModal.Nome;
            paciente.DataNascimento = editarViewModal.DataNascimento;

            _context.Update(paciente);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

    public IActionResult Excluir(int Id)
    {
        var paciente = _context.Pacientes.Find(Id);
        if (paciente != null)
        {
            return View(new ListarPacienteViewModal
            {
                Id = paciente.Id,
                CPF = paciente.CPF,
                Nome = paciente.Nome
            });
        }
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Excluir(int Id, ListarPacienteViewModal dados)
    {
        var paciente = _context.Pacientes.Find(Id);
        if (paciente != null)
        {
            _context.Remove(paciente);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

}