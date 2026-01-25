using Microsoft.EntityFrameworkCore;    // Importa o namespace do Entity Framework Core

namespace Asp.Net_Projeto04_Crud.Models;

public class BancoDados : DbContext     // DbContext é a classe que gerencia a conexão com o banco.
{

        // Criação da tabela Pessoas
        public DbSet<Pessoa> PessoaDB { get; set; }  // Transfere as informações da classe Pessoa Model/Pessoa.cs para a Variável PessoaDB

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Aqui você coloca sua senha do MySQL e outras configurações
            options.UseMySQL("server=localhost;database=projeto_crud;user=usuario_crud;password=123456");
        }
}


