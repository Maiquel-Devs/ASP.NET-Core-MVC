using Microsoft.EntityFrameworkCore;
using Asp.Net_Projeto06_TelaDeLogin.Models;

namespace Asp.Net_Projeto06_TelaDeLogin.Models
{
    public class BancoDados : DbContext
    {
        // Criação da tabela de usuários
        public DbSet<Usuario> UsuarioDB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=localhost;database=Meu_TelaLogin;user=Usuario;password=UsuarioSenha");
        }
    }
}