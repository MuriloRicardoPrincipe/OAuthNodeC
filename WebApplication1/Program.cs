using oauth.Modelo;

var builder = WebApplication.CreateBuilder(args);

// Registrar o HttpClient e o AuthService
builder.Services.AddHttpClient<AuthService>();

// Adicionar outros serviços necessários
builder.Services.AddControllersWithViews();

var app = builder.Build();



app.MapGet("/menu", async (AuthService authService) =>
{
    // Solicitar nome de usuário e senha via console
    Console.Write("Usuário: ");
    string username = Console.ReadLine();
    Console.Write("Senha: ");
    string password = Console.ReadLine();

    // Chamar o serviço de autenticação
    var token = await authService.AuthenticateAsync(username, password);

    if (!string.IsNullOrEmpty(token))
    {
        return Results.Ok("Login realizado com sucesso! Token: " + token);
    }
    else
    {
        return Results.Unauthorized();
    }
});

// Configurar o pipeline de solicitação HTTP
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
