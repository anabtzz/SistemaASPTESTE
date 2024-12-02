using Norget.Libraries.Login;
using Norget.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adicionar suporte ao IHttpContextAccessor para acesso ao contexto HTTP
builder.Services.AddHttpContextAccessor();

// Habilitar e configurar a sess�o
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Defina o tempo de expira��o da sess�o
    options.Cookie.IsEssential = true;  // Garantir que o cookie seja essencial
});

// Adicionar servi�os espec�ficos
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
builder.Services.AddScoped<Norget.Libraries.Session.Session>();
builder.Services.AddScoped<LoginUsuario>();
builder.Services.AddScoped<ICarrinhoRepositorio, CarrinhoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padr�o de HSTS � 30 dias. Voc� pode querer alter�-lo para cen�rios de produ��o, veja https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Habilitar o middleware de sess�o
app.UseSession();

app.UseRouting();
app.UseAuthorization();

// Configura��o da rota padr�o
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
