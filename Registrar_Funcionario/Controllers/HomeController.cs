using Microsoft.AspNetCore.Mvc;
using Registrar_Funcionario.COMPONENTES.BUS;
using Registrar_Funcionario.Models;

public class HomeController : Controller
{
    private readonly Bus_Funcionario _bus;

    public HomeController(Bus_Funcionario bus)
    {
        _bus = bus;
    }

    [HttpPost]
    public IActionResult Index(Funcionario funcionario)
    {
        if (!ModelState.IsValid)
            return View(funcionario);

        _bus.Cadastrar(funcionario);

        TempData["Mensagem"] = "Funcionário cadastrado com sucesso!";
        return RedirectToAction("Index");
    }

    public IActionResult Lista()
    {
        return View(_bus.Listar());
    }
}
