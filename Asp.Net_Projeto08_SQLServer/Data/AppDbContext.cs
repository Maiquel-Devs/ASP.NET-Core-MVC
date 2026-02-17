using Microsoft.EntityFrameworkCore;
using Asp.Net_Projeto08_SQLServer.Models;

namespace Asp.Net_Projeto08_SQLServer.Data;

public class AppDbContext : DbContext
{   
    // Criar uma tabela Usuario no banco de dados
    public DbSet<Usuario> Usuarios { get; set; }

    // Configurar a string de conexão com o banco de dados SQL Server
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

}
