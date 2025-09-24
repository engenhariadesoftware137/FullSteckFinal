using Repositorio;
using Servico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
// (Seus outros usings, como os dos projetos Repositorio, Servico, etc.)

var builder = WebApplication.CreateBuilder(args);

// Configurando InMemory DB
builder.Services.AddDbContext<EstudanteDbContext>(options =>
    options.UseInMemoryDatabase("EstudanteDb"));

// Registrando repositório e serviço
builder.Services.AddScoped<IEstudanteRepositorio, EstudanteRepositorio>();
builder.Services.AddScoped<IEstudanteServico, EstudanteServico>();

builder.Services.AddControllers();

// --- LINHAS NOVAS (PARA O SWAGGER) ---
// Adiciona os serviços para "descobrir" os endpoints da sua API
builder.Services.AddEndpointsApiExplorer();
// Adiciona o gerador do Swagger
builder.Services.AddSwaggerGen();
// --------------------------------------

var app = builder.Build();

// --- LINHAS NOVAS (PARA O SWAGGER) ---
// Configura o pipeline para usar o Swagger SÓ em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Isso gera o "documento" (swagger.json)
    app.UseSwaggerUI(); // Isso gera a página HTML interativa (em /swagger)
}
// --------------------------------------

// Você provavelmente tem essa linha (ou deveria ter), 
// já que sua URL está usando HTTPS
app.UseHttpsRedirection();

app.MapControllers();

app.Run();