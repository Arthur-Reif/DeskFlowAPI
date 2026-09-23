var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(op =>
    {
        op.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.Run();