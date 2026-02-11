using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto07_ProjetoAPI.Models;

namespace Asp.Net_Projeto07_ProjetoAPI.Controllers;

public class AccountController : Controller
{
    private BancoDados banco = new BancoDados();


    [HttpGet] 
    public IActionResult CriarConta()
    {
        return View(); 
    }

    
    [HttpPost]
    public IActionResult Registrar(Usuario input)
    {
        // Faz a varificação que criamos no Models.cs
        if (!ModelState.IsValid)
        {
            return View("CriarConta");
        }

        banco.UsuarioDB.Add(input);

        banco.SaveChanges();

        return RedirectToAction("Login");   
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();   
    }

    
    [HttpPost]
    public IActionResult ValidarConta(Usuario input)
    {
        // Verifica se existe um usuário com o nome e senha fornecidos
        var usuario = banco.UsuarioDB.FirstOrDefault(u => u.Nome == input.Nome && u.Senha == input.Senha);

        // Se não encontrar, exibe uma mensagem de erro
        if (usuario == null)
        {
            ViewBag.Erro = "Usuário ou senha inválidos.";
            return View("Login");  
        }

        // Se encontrar, salva o "carimbo" de login na sessão e redireciona para a página inicial
        HttpContext.Session.SetString("UsuarioLogado", usuario.Nome);

        return RedirectToAction("Index", "Home");
    }
}