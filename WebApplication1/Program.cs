using oauth.Modelo;

var builder = WebApplication.CreateBuilder(args);

// Registrar o HttpClient e o AuthService
builder.Services.AddHttpClient<AuthService>();

// Adicionar outros servi�os necess�rios
builder.Services.AddControllersWithViews();

var app = builder.Build();



app.MapGet("/menu", async (AuthService authService) =>
{
    // Solicitar nome de usu�rio e senha via console
    Console.Write("Usu�rio: ");
    string username = Console.ReadLine();
    Console.Write("Senha: ");
    string password = Console.ReadLine();

    // Chamar o servi�o de autentica��o
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

// Configurar o pipeline de solicita��o HTTP
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
