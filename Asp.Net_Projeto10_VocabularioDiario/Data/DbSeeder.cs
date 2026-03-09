using Asp.Net_Projeto10_VocabularioDiario.Models;
using System.IO;
using System.Linq;
using System.Text;

namespace Asp.Net_Projeto10_VocabularioDiario.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Só insere se o banco estiver vazio
            if (context.Palavras.Any()) return;

            var filePath = "Palavras.csv";

            if (File.Exists(filePath))
            {
                // Lê o arquivo usando UTF8 para não bugar acentos (ç, á, é)
                var linhas = File.ReadAllLines(filePath, Encoding.UTF8).Skip(1);

                foreach (var linha in linhas)
                {
                    var colunas = linha.Split(',');

                    if (colunas.Length >= 2)
                    {
                        context.Palavras.Add(new Palavra
                        {
                            Ingles = colunas[0].Trim(),
                            Portugues = colunas[1].Trim()
                        });
                    }
                }
                context.SaveChanges();
            }
        }
    }
}