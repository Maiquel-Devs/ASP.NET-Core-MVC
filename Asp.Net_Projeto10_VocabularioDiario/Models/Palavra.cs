using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Projeto10_VocabularioDiario.Models
{
    public class Palavra
    {
        [Key]   // Define que este é o ID (Chave Primária)
        public int Id { get; set; }

        [Required]  // Define que a coluna não pode ser nula
        [MaxLength(150)]
        public string Ingles { get; set; }

        [Required]
        [MaxLength(150)]
        public string Portugues { get; set; }
    }
}