using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto08_SQLServer.Models;

using Asp.Net_Projeto08_SQLServer.Data; // Importar o contexto do banco de dados para o controlador

namespace Asp.Net_Projeto08_SQLServer.Controllers;

public class HomeController : Controller
{

    // Variavel Global para acessar o banco de dados
    private readonly AppDbContext _context;

    // Injetar o contexto do banco de dados no controlador
    public HomeController(AppDbContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {
        // Busca todos os usuários do SQL Server
        var lista = _context.Usuarios.ToList();

        // Onde será enviado os dados para a View
        ViewBag.Usuarios = lista;
        
        return View();
    }

    // Ação do formulário CadastrarPessoa
    public IActionResult CadastrarPessoa(Usuario input)
    {
        // Cadastrar um novo usuário no SQL Server
        _context.Usuarios.Add(input);

        // Salvar as alterações no banco de dados
        _context.SaveChanges();

        return RedirectToAction("Index");
    }


    // ----------------------------------------------------------------------------

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
