using Microsoft.EntityFrameworkCore;
using Asp.Net_Projeto09_ProjetoFinTrack.Models;

namespace Asp.Net_Projeto09_ProjetoFinTrack.Data;

public class ApplicationDbContext : DbContext
{
    // Cria a Tabela
    public DbSet<Transacao> Transacoes { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    } 
}
