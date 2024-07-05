using Microsoft.AspNetCore.Mvc;

namespace GenConMedico.Controllers;

public class MedicosController : Controller
{

    public IActionResult Index(){
        return View();
    }
}
