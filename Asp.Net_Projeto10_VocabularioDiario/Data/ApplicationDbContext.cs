using Microsoft.EntityFrameworkCore;
using Asp.Net_Projeto10_VocabularioDiario.Models; 

namespace Asp.Net_Projeto10_VocabularioDiario.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Tabelas do banco de dados
        public DbSet<Palavra> Palavras { get; set; }
        public DbSet<RegistroResposta> RegistroRespostas { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }    
    }
}