using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto10_VocabularioDiario.Data;
using Asp.Net_Projeto10_VocabularioDiario.Models;

namespace Asp.Net_Projeto10_VocabularioDiario.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // 1. Procura palavras que o utilizador ainda NÃO respondeu
            var respondidasIds = _context.RegistroRespostas.Select(r => r.PalavraId).ToList();

            var correta = _context.Palavras
                .Where(p => !respondidasIds.Contains(p.Id))
                .OrderBy(r => Guid.NewGuid())
                .FirstOrDefault();

            if (correta == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            // 2. Lógica de Dificuldade (Tamanhos parecidos)
            int tamanhoAlvo = correta.Portugues.Length;

            var erradas = _context.Palavras
                .Where(p => p.Id != correta.Id)
                .Where(p => p.Portugues.Length >= tamanhoAlvo - 3 && p.Portugues.Length <= tamanhoAlvo + 3)
                .OrderBy(r => Guid.NewGuid())
                .Take(3)
                .ToList();

            if (erradas.Count < 3)
            {
                erradas = _context.Palavras
                    .Where(p => p.Id != correta.Id)
                    .OrderBy(r => Guid.NewGuid())
                    .Take(3)
                    .ToList();
            }

            // 3. Montar e embaralhar alternativas
            var alternativas = erradas.Select(e => e.Portugues).ToList();
            alternativas.Add(correta.Portugues);
            alternativas = alternativas.OrderBy(a => Guid.NewGuid()).ToList();

            // --- PASSAGEM DE DADOS PARA A VIEW ---
            ViewBag.Ingles = correta.Ingles;
            ViewBag.Id = correta.Id;
            ViewBag.Alternativas = alternativas;
            
            // Envia a resposta correta para o JavaScript
            ViewBag.RespostaCorreta = correta.Portugues; 

            return View();
        }

        [HttpPost]
        public IActionResult Responder(int id, string answer)
        {
            var palavra = _context.Palavras.Find(id);
            if (palavra == null) return RedirectToAction("Index");

            bool acertou = (palavra.Portugues.Trim().ToLower() == answer.Trim().ToLower());

            var registro = new RegistroResposta
            {
                PalavraId = id,
                Acertou = acertou,
                DataResposta = DateTime.Now
            };

            _context.RegistroRespostas.Add(registro);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}