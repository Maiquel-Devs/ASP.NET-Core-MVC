using Microsoft.EntityFrameworkCore;    // Importar o Entity Framework Core para configurar o contexto do banco de dados
using Asp.Net_Projeto08_SQLServer.Data; // Importar o contexto do banco de dados para registrar o serviço no contêiner de injeção de dependência


var builder = WebApplication.CreateBuilder(args);

// Pega a string de conexão do arquivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Usa a permissão do SQL Server para acessar o banco de dados (Cujo criei no proprio Banco de Dados do SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
