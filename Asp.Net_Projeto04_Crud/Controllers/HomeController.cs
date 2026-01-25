using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto04_Crud.Models;

namespace Asp.Net_Projeto04_Crud.Controllers;

public class HomeController : Controller
{

    // Conexão com o banco de dados
    private BancoDados banco = new BancoDados();

    public IActionResult Index()
    {
        
        // Garante que o banco de dados e as tabelas existam
        banco.Database.EnsureCreated();  

        // Busca a lista diretamente da tabela do MySQL
        var lista = banco.PessoaDB.ToList();

        // Variavel usada para mandar informações para o arquivo HTML
        ViewBag.Pessoas = lista;

        return View();
    }

    // Função para Adicioar 
    [HttpPost]
    public IActionResult Adicionar(Pessoa input)
    {
        // Adiciona o objeto 'input' na tabela Pessoas do banco
        banco.PessoaDB.Add(input);

        // Salva as mudanças de fato no arquivo do banco de dados (COMMIT)
        banco.SaveChanges();

        return RedirectToAction("Index");   // Redireciona para a ação Index
    }

    // Função para Excluir
    public IActionResult Excluir(int id)
    {
        // Busca a pessoa pelo ID diretamente no banco de dados
        var pessoa = banco.PessoaDB.Find(id);

        if (pessoa != null)
        {
            banco.PessoaDB.Remove(pessoa); // Marca para remover
            banco.SaveChanges();          // Executa o DELETE no MySQL
        }

        return RedirectToAction("Index");
    }

    // Função para Editar (Atualizar)
    public IActionResult Editar(int id)
    {
        // Busca os dados da pessoa para preencher o formulário de edição
        var pessoa = banco.PessoaDB.Find(id);
        return View(pessoa);
    }


    // Função para Confirmar a Edição (Salva no banco)
    [HttpPost]
    public IActionResult ConfirmarEdicao(Pessoa input)
    {
        // O comando Update avisa que este objeto (com o mesmo ID) tem novos dados
        banco.PessoaDB.Update(input);
        banco.SaveChanges(); // Executa o UPDATE no MySQL

        return RedirectToAction("Index");
    }


    // -----------------------------------------------------------------------------------------

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
