namespace Asp.Net_Projeto07_ProjetoAPI.Models;

public class StockViewModel
{
    public string? Symbol { get; set; } // Símbolo da ação
    public string? Date { get; set; }   // Data da cotação
    public string? Open { get; set; }   // Preço de abertura
    public string? High { get; set; }   // Preço mais alto
    public string? Low { get; set; }    // Preço mais baixo
    public string? Close { get; set; }  // Preço de fechamento
    public string? ErrorMessage { get; set; }   // Mensagem de erro, caso ocorra algum problema ao obter os dados
}
