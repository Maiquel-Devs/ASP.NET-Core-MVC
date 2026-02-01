using System.Text.Json;  // Biblioteca para trabalhar com JSON (parsear, ler, etc)

// URL da API pública de clima com coordenadas de São Paulo e pedido do clima atual
string url = "https://api.open-meteo.com/v1/forecast?latitude=-23.55&longitude=-46.63&current_weather=true";

// Cria uma instância do HttpClient para fazer requisições HTTP
using HttpClient client = new HttpClient();

try
{
    // Faz a requisição GET para a URL da API e aguarda o retorno como string JSON
    string json = await client.GetStringAsync(url);

    // Parseia a string JSON para um objeto JsonDocument para navegar no JSON
    using JsonDocument doc = JsonDocument.Parse(json);

    // Obtém o elemento raiz do JSON para começar a acessar as propriedades
    var root = doc.RootElement;

    // Acessa o objeto "current_weather" dentro do JSON, que tem os dados do clima atual
    var currentWeather = root.GetProperty("current_weather");

    // Pega o valor da temperatura como double (número decimal)
    double temperature = currentWeather.GetProperty("temperature").GetDouble();

    // Pega o valor da velocidade do vento como double
    double windspeed = currentWeather.GetProperty("windspeed").GetDouble();

    // Pega o valor do código do clima como string (JSON cru)
    string weatherCode = currentWeather.GetProperty("weathercode").GetRawText();

    // Imprime no console a mensagem "Clima Atual - São Paulo"
    Console.WriteLine("Clima Atual - São Paulo");

    // Imprime no console a temperatura formatada
    Console.WriteLine($"Temperatura: {temperature}°C");

    // Imprime no console a velocidade do vento formatada
    Console.WriteLine($"Velocidade do Vento: {windspeed} km/h");

    // Imprime no console o código do clima
    Console.WriteLine($"Código do Clima: {weatherCode}");
}
catch (Exception ex)  // Se ocorrer qualquer erro na requisição ou no processamento
{
    // Mostra mensagem de erro no console
    Console.WriteLine("Erro ao acessar API de clima:");

    // Mostra detalhes da exceção (mensagem do erro)
    Console.WriteLine(ex.Message);
}
