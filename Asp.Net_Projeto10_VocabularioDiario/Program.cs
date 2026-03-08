using Microsoft.EntityFrameworkCore;
using Asp.Net_Projeto10_VocabularioDiario.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura a conexão com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Executa o Seeder para popular as 1996 palavras no SQL Server
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    Asp.Net_Projeto10_VocabularioDiario.Data.DbSeeder.Seed(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthorization();

// Ajustado para abrir direto no QuizController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quiz}/{action=Index}/{id?}");


app.Run();