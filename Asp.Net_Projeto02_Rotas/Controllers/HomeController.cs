using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto02_Rotas.Models;

namespace Asp.Net_Projeto02_Rotas.Controllers;

public class HomeController : Controller
{
    // Gera Rota raiz padrão: localhost:5000/  
    public IActionResult Index()
    {
        return View();  // Busca por convenção: Views/Home/Index.cshtml
    }


    // Gera Rota localhost:5000/Home/Produtos   
    public IActionResult Produtos()     // Apenas escrever o nome do arquivo cshtml que ele já encontra na pasta Views/Home
    {
        return View();  // Busca por convenção: Views/Home/Produtos.cshtml
    }

    // Cria Rota personalizada usando Atributo: localhost:5000/fale-conosco
    [Route("fale-conosco")]     // Deixa a rota mais limpa , sem o padrão /Home/Contato
    public IActionResult Contato()      // Apenas escrever o nome do arquivo cshtml que ele já encontra na pasta Views/Home
    {
        return View();  // Mesmo com rota personalizada, ainda busca Views/Home/Contato.cshtml
    }


    // --------------------------------------------------------------------------------------------------

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
