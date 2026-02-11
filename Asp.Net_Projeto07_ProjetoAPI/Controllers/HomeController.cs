using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto07_ProjetoAPI.Models;
using System.Text.Json;

namespace Asp.Net_Projeto07_ProjetoAPI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Verifica se existe o "carimbo" de login na sessão
        if (HttpContext.Session.GetString("UsuarioLogado") == null)
        {
            
            return RedirectToAction("Login", "Account");
        }

        
        return View();  
    }


    [HttpPost]
    public async Task<IActionResult> BuscarAcao(string symbol)
    {        
        if (string.IsNullOrEmpty(symbol)) return View("Index");

        string apiKey = "GYJ8ZYZM37N0FIR8";
        string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={apiKey}";

        using HttpClient client = new HttpClient();

        try
        {
            string response = await client.GetStringAsync(url);
            using JsonDocument doc = JsonDocument.Parse(response);
            JsonElement root = doc.RootElement;

            if (!root.TryGetProperty("Time Series (Daily)", out var timeSeries))
            {
                ViewBag.Erro = "Simbolo não encontrado ou limite da API atigindo.";
                return View("Index");
            }

            var day = timeSeries.EnumerateObject().First();
            var values = day.Value;

            // Variavel do tipo StockViewModel para armazenar os dados da ação
            var model = new StockViewModel  
            {
                Symbol = symbol.ToUpper(),
                Date = day.Name,
                Open = values.GetProperty("1. open").GetString(),
                High = values.GetProperty("2. high").GetString(),
                Low = values.GetProperty("3. low").GetString(),
                Close = values.GetProperty("4. close").GetString(),
            };

            return View("Index", model);    // Envia a variavel para a view
        }
        catch
        {
            ViewBag.Erro = "Erro ao conectar com a API.";
            return View("Index");
        }        
    }

   
    // ------------------------------------------------------------------------------


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