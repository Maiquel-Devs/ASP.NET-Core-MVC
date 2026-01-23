var builder = WebApplication.CreateBuilder(args);

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

// DEFINE A PORTA DE ENTRADA DO SITE (ROTA RAIZ)
// Este comando diz ao .NET: "Se o usuário acessar o site e não digitar nenhum caminho,
// carregue automaticamente o controlador 'Home' e execute a função 'Index'."
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
