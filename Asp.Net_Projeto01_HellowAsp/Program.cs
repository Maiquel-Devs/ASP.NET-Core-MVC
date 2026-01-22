// Cria o construtor da aplicação com configurações iniciais
var builder = WebApplication.CreateBuilder(args);

// Registra serviços MVC para usar controllers e views
builder.Services.AddControllersWithViews();

// Monta a aplicação com as configurações feitas
var app = builder.Build();

// Configura o tratamento de erros e segurança para produção
if (!app.Environment.IsDevelopment())
{
    // Página amigável para erros
    app.UseExceptionHandler("/Home/Error");
    // Ativa HSTS para reforçar uso de HTTPS
    app.UseHsts();
}

// Redireciona requisições HTTP para HTTPS automaticamente
app.UseHttpsRedirection();

// Permite servir arquivos estáticos da pasta wwwroot (CSS, JS, imagens)
app.UseStaticFiles();

// Ativa o sistema de roteamento para mapear URLs aos controllers/actions
app.UseRouting();

// Ativa a verificação de autorização (para áreas protegidas)
app.UseAuthorization();

// Define a rota padrão: controller/action/id (id é opcional)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia o servidor e começa a receber requisições
app.Run();