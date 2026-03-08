using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto10_VocabularioDiario.Data;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Projeto10_VocabularioDiario.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Busca todos os registros incluindo os dados da palavra
            var historico = _context.RegistroRespostas
                .Include(r => r.Palavra)
                .OrderByDescending(r => r.DataResposta)
                .ToList();

            // Dados para o gráfico
            ViewBag.TotalAcertos = historico.Count(r => r.Acertou);
            ViewBag.TotalErros = historico.Count(r => !r.Acertou);

            // Listas separadas para as tabelas
            ViewBag.ListaAcertos = historico.Where(r => r.Acertou).ToList();
            ViewBag.ListaErros = historico.Where(r => !r.Acertou).ToList();

            return View();
        }
    }
}