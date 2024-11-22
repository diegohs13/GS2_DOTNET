using Gs2DotNet.Data;
using Gs2DotNet.Models;
using Gs2DotNet.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Gs2DotNet.Controller;

public static class ModuloController
{
     public static void MapEndpointsModulo (this WebApplication app)
    {
        var endpointsModulos = app.MapGroup("modulos");

        // Adiciona um modulo no banco de dados utilizando o método POST
        endpointsModulos.MapPost("", async (AddModuloRequest request, AppDbContext context) =>
        {
            var verificacao = await context.Modulos.
                FirstOrDefaultAsync(modulo => modulo.Id == request.Id);

            if (verificacao != null)
            {
                return Results.Conflict("Já existe um modulo cadastrado com esse Id");
            }

            var novoModulo = new Modulo(request.Id, request.Titulo, request.Descricao,
                request.Nivel);

            await context.Modulos.AddAsync(novoModulo);
            await context.SaveChangesAsync();

            return Results.Ok(novoModulo);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Cria umo novo modulo", description: "Adiciona um novo modulo ao banco de dados."));

        // Retorna todos modulo cadastrados no banco de dados utilizando o método GET
        endpointsModulos.MapGet("", async (AppDbContext context) =>
        {
            var todosModulos = await context.Modulos.ToListAsync();
            return todosModulos;
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Lista todo os modulo", description: "Retorna todos os modulo cadastradas no sistema."));

        // Retorna um modulo específic pelo id utilizando o método GET
        endpointsModulos.MapGet("{id}", async (string id, AppDbContext context) =>
        {
            var modulo = await context.Modulos.FirstOrDefaultAsync(modulo => modulo.Id == id);
            return modulo == null ? Results.NotFound() : Results.Ok(modulo);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Obtém um modulo", description: "Retorna um modulo específica pelo Id."));

        // Atualiza a descrição id utilizando o método PUT
        endpointsModulos.MapPut("{id}", async (string id, PutModuloRequest request, AppDbContext context) =>
        {
            var modulo = await context.Modulos.FirstOrDefaultAsync(modulo => modulo.Id == id);

            if (modulo == null)
            {
                return Results.NotFound();
            }

            modulo.AtualzarDescricao(request.Descricao);
            await context.SaveChangesAsync();

            return Results.Ok(modulo);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Atualiza um modulo", description: "Atualiza a descrição de um modulo pelo Id."));

        // Deleta um modulo específica pelo id utilizando o método DELETE
        endpointsModulos.MapDelete("{id}", async (string id, AppDbContext context) =>
        {
            var modulo = await context.Modulos.FirstOrDefaultAsync(modulo => modulo.Id == id);

            if (modulo == null)
            {
                return Results.NotFound();
            }

            context.Modulos.Remove(modulo);
            await context.SaveChangesAsync();

            return Results.Ok();
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Deleta um modulo", description: "Deleta um modulo específico pelo Id."));
    }
}