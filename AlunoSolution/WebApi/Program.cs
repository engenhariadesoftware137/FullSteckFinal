using Repositorio;
using Servico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
// (Seus outros usings, como os dos projetos Repositorio, Servico, etc.)

var builder = WebApplication.CreateBuilder(args);

// Configurando InMemory DB
builder.Services.AddDbContext<EstudanteDbContext>(options =>
    options.UseInMemoryDatabase("EstudanteDb"));

// Registrando reposit�rio e servi�o
builder.Services.AddScoped<IEstudanteRepositorio, EstudanteRepositorio>();
builder.Services.AddScoped<IEstudanteServico, EstudanteServico>();

builder.Services.AddControllers();

// --- LINHAS NOVAS (PARA O SWAGGER) ---
// Adiciona os servi�os para "descobrir" os endpoints da sua API
builder.Services.AddEndpointsApiExplorer();
// Adiciona o gerador do Swagger
builder.Services.AddSwaggerGen();
// --------------------------------------

var app = builder.Build();

// --- LINHAS NOVAS (PARA O SWAGGER) ---
// Configura o pipeline para usar o Swagger S� em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Isso gera o "documento" (swagger.json)
    app.UseSwaggerUI(); // Isso gera a p�gina HTML interativa (em /swagger)
}
// --------------------------------------

// Voc� provavelmente tem essa linha (ou deveria ter), 
// j� que sua URL est� usando HTTPS
app.UseHttpsRedirection();

app.MapControllers();

app.Run();