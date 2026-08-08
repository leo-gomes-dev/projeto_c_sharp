var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// 🛡️ MIDDLEWARE DEFINITIVO DE CORS (Injeta os cabeçalhos na marra)
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
    context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, POST, OPTIONS, PUT, DELETE");
    context.Response.Headers.Append("Access-Control-Allow-Headers", "Content-Type, Authorization");

    // Se o navegador enviar um "Preflight" (OPTIONS), nós respondemos 200 OK imediatamente e paramos aqui
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 200;
        await context.Response.CompleteAsync();
        return;
    }

    await next();
});

// Dados em memória
var listaDevs = new List<Desenvolvedor>
{
    new Desenvolvedor("Lucas", "JavaScript (Front)"),
    new Desenvolvedor("Voce", "C# .NET (Back)")
};

// Rotas limpas
app.MapGet("/api/devs", () => listaDevs);

app.MapPost("/api/devs", (Desenvolvedor novoDev) => 
{
    if (string.IsNullOrEmpty(novoDev.Nome) || string.IsNullOrEmpty(novoDev.Tecnologia))
    {
        return Results.BadRequest("Dados inválidos!");
    }

    listaDevs.Add(novoDev);
    return Results.Created($"/api/devs", novoDev);
});

app.Run();

record Desenvolvedor(string Nome, string Tecnologia);
