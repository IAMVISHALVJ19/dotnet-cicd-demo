var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();
var app = builder.Build();

app.MapGet("/", () => "Hello from the .NET monolith");
app.MapGet("/api/add/{a:int}/{b:int}", (int a, int b) => Calculator.Add(a, b));
app.MapHealthChecks("/health");
app.Run();

public static class Calculator
{
    public static int Add(int a, int b) => a + b;
}

public partial class Program { }
