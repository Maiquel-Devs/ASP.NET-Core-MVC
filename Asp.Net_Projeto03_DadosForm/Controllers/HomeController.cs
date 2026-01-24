using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto03_DadosForm.Models;

namespace Asp.Net_Projeto03_DadosForm.Controllers;

public class HomeController : Controller
{

    // Variável que guarda a lista de pessoas digitadas
    private static List<Pessoa> listaGeral = new List<Pessoa>();    // Lista gerada daquela classe Pessoa.cs
    public IActionResult Index()
    {
        
        ViewBag.Pessoas = listaGeral;   // Quando abre o site pela primeira vez, já manda a lista (mesmo vazia)
        return View();
    }

    
    [HttpPost]  // Indica que esse método só responde a requisições POST
    public IActionResult Processar(Pessoa input)    // ** Código responsável por gerar a função "Processar" do formulário HTML
    {
        listaGeral.Add(input);        // Guarda o que você digitou
        ViewBag.Pessoas = listaGeral; // Atualiza a "sacola" que o HTML vai ler
        return View("Index");         // Recarrega a mesma página com o dado novo
    }

    // ----------------------------------------------------------------------------------------------




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
