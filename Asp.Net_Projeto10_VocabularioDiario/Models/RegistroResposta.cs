using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_Projeto10_VocabularioDiario.Models
{
    public class RegistroResposta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PalavraId { get; set; }

        // Isso cria a relação (Chave Estrangeira) com a tabela de Palavras
        [ForeignKey("PalavraId")]
        public Palavra Palavra { get; set; }

        [Required]
        public bool Acertou { get; set; } // True = Acertou, False = Errou

        [Required]
        public DateTime DataResposta { get; set; } = DateTime.Now;
    }
}