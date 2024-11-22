using Gs2DotNet.Data;
using Gs2DotNet.Models;
using Gs2DotNet.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Gs2DotNet.Controller;

public static class ConteudoController
{
    public static void MapEndpointsConteudo(this WebApplication app)
    {
        var endpointsConteudos = app.MapGroup("conteudos");

        // Adiciona um novo conteudo no banco de dados utilizando o método POST
        endpointsConteudos.MapPost("", async (AddConteudoRequest request, AppDbContext context) =>
        {
            // Verifica se já existe um conteudo com o mesmo Id cadastrado
            var verificacao = await context.Conteudos.FirstOrDefaultAsync(conteudo => conteudo.Id == request.Id);

            if (verificacao != null)
            {
                return Results.Conflict("Já existe um conteudo cadastrado com esse Id");
            }

            var novoConteudo = new Conteudo(request.Id, request.Tipo, request.Descricao);

            await context.Conteudos.AddAsync(novoConteudo);
            await context.SaveChangesAsync();

            return Results.Ok(novoConteudo);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Cria um novo conteudi", description: "Adiciona um novo conteudo ao banco de dados."));

        // Retorna todos os conteudos utilizando o método GET
        endpointsConteudos.MapGet("", async (AppDbContext context) =>
        {
            var todosConteudos = await context.Conteudos.ToListAsync();
            return todosConteudos;
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Lista todos os conteudos", description: "Retorna todos os conteudos cadastrados no sistema."));

        // Retorna um conteudo pelo Id utilizando o método GET
        endpointsConteudos.MapGet("{id}", async (string id, AppDbContext context) =>
        {
            var conteudo = await context.Conteudos.FirstOrDefaultAsync(conteudo => conteudo.Id == id);
            return conteudo == null ? Results.NotFound() : Results.Ok(conteudo);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Obtém um conteudo", description: "Retorna um conteudo específico pelo Id."));

        // Atualiza a senha do paciente pelo CPF utilizando o método PUT
        endpointsConteudos.MapPut("/{id}/atualizarDescricao", async (string id, PutConteudoRequest request, AppDbContext context) =>
        {
            var conteudo = await context.Conteudos.FirstOrDefaultAsync(conteudo => conteudo.Id == id);

            if (conteudo == null)
            {
                return Results.NotFound();
            }

            conteudo.AtualizarDescricao(request.Descricao);
            await context.SaveChangesAsync();
            return Results.Ok(conteudo);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Atualiza a descrição de um conteudo", description: "Atualiza a descrição de um conteudo pelo Id."));

        // Deleta um paciente pelo CPF utilizando o método DELETE
        endpointsConteudos.MapDelete("{id}", async (string id, AppDbContext context) =>
        {
            var conteudo = await context.Conteudos.FirstOrDefaultAsync(conteudo => conteudo.Id == id);

            if (conteudo == null)
            {
                return Results.NotFound();
            }

            context.Conteudos.Remove(conteudo);
            await context.SaveChangesAsync();

            return Results.Ok("conteudo deletado com sucesso");
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Deleta um conteudo", description: "Deleta um conteudo específico pelo Id."));
    }
}