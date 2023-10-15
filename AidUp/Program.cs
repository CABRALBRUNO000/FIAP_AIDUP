using AidUp.Models;
using AidUp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AidupDatabaseSettings>(
    builder.Configuration.GetSection("AidUpDatabase"));

builder.Services.AddSingleton<InstituicaoRepository>();
builder.Services.AddSingleton<UsuarioRepository>();
builder.Services.AddSingleton<ProgramacaoRepository>();
builder.Services.AddSingleton<ArtigoRepository>();
builder.Services.AddSingleton<ComunicadoRepository>();
builder.Services.AddSingleton<DevocionalRepository>();
builder.Services.AddSingleton<EnqueteRepository>();
builder.Services.AddSingleton<EventoRepository>();
builder.Services.AddSingleton<LembreteRepository>();
builder.Services.AddSingleton<PostRepository>();
builder.Services.AddSingleton<TarefaRepository>();


builder.Services.AddControllers()
     .AddNewtonsoftJson().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
