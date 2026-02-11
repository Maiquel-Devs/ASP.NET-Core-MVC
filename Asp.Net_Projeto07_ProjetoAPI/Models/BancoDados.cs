using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Projeto07_ProjetoAPI.Models;

public class BancoDados : DbContext
{
    // Criação da tabela de usuários
    public DbSet<Usuario> UsuarioDB { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySQL("server=localhost;database=ProjetoAPI;user=UsuarioAPI;password=SenhaAPI");
    }
}
