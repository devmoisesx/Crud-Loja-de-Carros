using System.Reflection.Metadata;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;

    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new()
        {
            Title = "Loja de Carros API",
            Version = "V1",
            Description = "API para gerenciamento de loja de carros."
        };
        return Task.CompletedTask;
    });
});

builder.Services.AddControllers();

builder.Services.AddSingleton<StorageCarroSqlite>();
builder.Services.AddSingleton<StorageClienteSqlite>();
builder.Services.AddSingleton<StorageTransacaoSqlite>();

builder.Services.AddScoped<IServiceCarro, ServiceCarro>();
builder.Services.AddScoped<ServiceCarro>();
builder.Services.AddScoped<IServiceCliente, ServiceCliente>();
builder.Services.AddScoped<ServiceCliente>();
builder.Services.AddScoped<IServiceTransacao, ServiceTransacao>();
builder.Services.AddScoped<ServiceTransacao>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var storage = scope.ServiceProvider.GetRequiredService<StorageCarroSqlite>();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/v1/openapi.json");
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();