using Gs2DotNet.Controller;
using Gs2DotNet.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});
builder.Services.AddScoped<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpointsEstudante();
app.MapEndpointsConteudo();
app.MapEndpointsModulo();
app.MapEndpointsTurma();

app.Run();