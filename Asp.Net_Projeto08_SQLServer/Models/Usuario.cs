using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Projeto08_SQLServer.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
 
    public string Nome { get; set; }

    public int Idade { get; set; }
}
