using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto09_ProjetoFinTrack.Models; // Models
using Asp.Net_Projeto09_ProjetoFinTrack.Data;   // Banco de Dados

namespace Asp.Net_Projeto09_ProjetoFinTrack.Controllers;

public class HomeController : Controller
{

    private readonly ApplicationDbContext _context;

    // O construtor recebe o Banco de Dados que configuramos no Program.cs
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }


    // 1. TELA DO GRÁFICO (Index)
    public IActionResult Index()
    {
        // Busca todas as transações do banco
        var transacoes = _context.Transacoes.ToList();

        // Soma os valores por tipo
        decimal totalRenda = transacoes.Where(t => t.Tipo == "Renda").Sum(t => t.Valor);
        decimal totalDespesa = transacoes.Where(t => t.Tipo == "Despesa").Sum(t => t.Valor);

        // Cálculo da Porcentagem
        decimal porcentagem = 0;

        if (totalRenda > 0)
        {
            porcentagem = (totalDespesa / totalRenda) * 100;
        }

        // Passa os valores para a View via ViewBag
        ViewBag.TotalRenda = totalRenda;
        ViewBag.TotalDespesa = totalDespesa;
        ViewBag.Porcentagem = porcentagem;

        return View();
    }


    // 2. TELA DOS FORMULÁRIOS (Lancamentos)
    public IActionResult Lancamentos()
    {
        // Busca e ordena do mais caro para o mais barato
        var lista = _context.Transacoes.OrderByDescending(t => t.Valor).ToList();
        return View(lista);
    }


    // 3. LOGICA PARA SALVAR RENDA
    [HttpPost]
    public IActionResult SalvarRenda(Transacao input)
    {   
        // Escolhe o Tipo "Renda" (Models)
        input.Tipo = "Renda";
    
        _context.Transacoes.Add(input);
        _context.SaveChanges();


        return RedirectToAction("Lancamentos");
    }


    // 4. LOGICA PARA SALVAR DESPESA
    [HttpPost]
    public IActionResult SalvarDespesa(Transacao input)
    {
        // Escolhe o Tipo "Despesa" (Models)
        input.Tipo = "Despesa";

        _context.Transacoes.Add(input);
        _context.SaveChanges();


        return RedirectToAction("Lancamentos");
    }


    // 5. LOGICA PARA EXCLUIR
    public IActionResult Excluir(int id)
    {
        // Procura o ID para fazer a remoção
        var transacao = _context.Transacoes.Find(id);
        if (transacao != null)
        {
            _context.Transacoes.Remove(transacao);
            _context.SaveChanges();
        }


        return RedirectToAction("Lancamentos");
    }


    // 6. LÓGICA PARA ATUALIZAR O LANÇAMENTO (Via Modal)
    [HttpPost]
    public IActionResult Editar(Transacao input)
    {
        // Procura o ID para fazer a alteração dos dados
        var lancamentoNoBanco = _context.Transacoes.Find(input.Id);

        if (lancamentoNoBanco != null)
        {
            lancamentoNoBanco.Nome = input.Nome;
            lancamentoNoBanco.Categoria = input.Categoria;
            lancamentoNoBanco.Valor = input.Valor;

            _context.Transacoes.Update(lancamentoNoBanco);
            _context.SaveChanges();
        }


        return RedirectToAction("Lancamentos");
    }
        



    // ----------------------------------------------------------------------------------------

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
