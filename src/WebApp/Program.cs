using WebApp.DependencyInjection;
using TechnicalTest.Infrastructure.DependencyInjection;
using TechnicalTest.Application.DependencyInjection;
using WebApp.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors(policy =>
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalExceptionHandler>();

app.Run();
