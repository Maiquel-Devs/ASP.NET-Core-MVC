using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Projeto06_TelaDeLogin.Models;

public class Usuario
{
    [Key]   // Define a propriedade Id como chave primária (ela garante isso, apesar do MySQL fazer isso automaticamente)
    public int Id { get; set; }


    [Required(ErrorMessage = "Digite o nome de usuário.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "O usuário deve ter entre 3 e 20 caracteres.")]  // Define o tamanho
    public string Nome { get; set; }


    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")] // Define o tamanho
    public string Senha { get; set; }
}