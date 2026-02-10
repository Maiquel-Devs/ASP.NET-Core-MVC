var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();  // Adiciona o serviço de sessão
builder.Services.AddHttpContextAccessor(); // Ajuda o Controller a acessar a sessão

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); 

app.UseRouting();

app.UseSession(); // Habilita o uso de sessão

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");  // Mudei a rota padrão para Login (Views/Account/Login.cshtml).

app.Run();
