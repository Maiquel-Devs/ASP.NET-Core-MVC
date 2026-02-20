using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Projeto09_ProjetoFinTrack.Models;

public class Transacao
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }    // Ex: "Netflix" ou "Academia"

    [Required]
    public string Categoria { get; set; }   // Ex: "Streamim" ou "Saude"

    [Required]
    public decimal Valor { get; set; }

    public string Tipo { get; set; }    // Renda ou Despesa
}
