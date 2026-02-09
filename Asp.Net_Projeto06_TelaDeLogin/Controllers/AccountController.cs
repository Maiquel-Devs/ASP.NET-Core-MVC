using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto06_TelaDeLogin.Models;

namespace Asp.Net_Projeto06_TelaDeLogin.Controllers;

public class AccountController : Controller
{
    // Acesso ao banco de dados
    private BancoDados banco = new BancoDados();

    // Acessa a pagina de CriarConta
    [HttpGet] 
    public IActionResult CriarConta()
    {
        return View();  // Views/Account/CriarConta.cshtml
    }

    // Acessa o formulário de Registrar (no arquivo CriarConta.cshtml)
    [HttpPost]
    public IActionResult Registrar(Usuario input)
    {
        // Verifica se as regras (MinLength, Required) foram respeitadas
        if (!ModelState.IsValid)
        {
            return View("CriarConta");
        }

        banco.UsuarioDB.Add(input);

        banco.SaveChanges();

        return RedirectToAction("Login", "Home");   // Redireciona para Login no HomeController.cs, que redireciona para Login no AccountController.cs
    }


    // Acessa a pagina de Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();      // Views/Account/Login.cshtml
    }

    // Acessa o formulário de ValidarConta (no arquivo Login.cshtml)
    [HttpPost]
    public IActionResult ValidarConta(Usuario input)
    {
        // Verifica se existe um usuário com o nome e senha fornecidos
        var usuario = banco.UsuarioDB.FirstOrDefault(u => u.Nome == input.Nome && u.Senha == input.Senha);

        // Se não encontrar, exibe uma mensagem de erro
        if (usuario == null)
        {
            ViewBag.Erro = "Usuário ou senha inválidos.";
            return View("Login");   // Volta para Login no HomeController.cs, que redireciona para Login no AccountController.cs, que exibe a mensagem de erro
        }

        // Se encontrar, cria um "carimbo" de login na sessão
        HttpContext.Session.SetString("UsuarioLogado", usuario.Nome);

        return RedirectToAction("Index", "Home");   // Controller/HomeController.cs função Index()
    }

}
