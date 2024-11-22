using Gs2DotNet.Data;
using Gs2DotNet.Models;
using Gs2DotNet.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Gs2DotNet.Controller;

public static class TurmaController
{
    public static void MapEndpointsTurma(this WebApplication app)
    {
        var endpointsTurmas = app.MapGroup("turmas");

        // Adiciona uma nova turma no banco de dados utilizando o método POST
        endpointsTurmas.MapPost("", async (AddTurmaRequest request, AppDbContext context) =>
        {
            var verificacao = await context.Turmas.
                FirstOrDefaultAsync(turma => turma.Id == request.Id);

            if (verificacao != null)
            {
                return Results.Conflict("Já existe uma turma cadastrada com esse Id");
            }

            var novaTurma = new Turma(request.Id, request.Nome_turma, request.Ano);

            await context.Turmas.AddAsync(novaTurma);
            await context.SaveChangesAsync();

            return Results.Ok(novaTurma);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Cria uma nova turma", description: "Adiciona uma nova turma ao banco de dados."));

        // Retorna todas as turma cadastradas no banco de dados utilizando o método GET
        endpointsTurmas.MapGet("", async (AppDbContext context) =>
        {
            var todasTurmas = await context.Turmas.ToListAsync();
            return todasTurmas;
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Lista todas as turma", description: "Retorna todas as turma cadastradas no sistema."));

        // Retorna uma turma específica pelo id utilizando o método GET
        endpointsTurmas.MapGet("{id}", async (string id, AppDbContext context) =>
        {
            var turma = await context.Turmas.FirstOrDefaultAsync(turma => turma.Id == id);
            return turma == null ? Results.NotFound() : Results.Ok(turma);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Obtém uma turma", description: "Retorna uma turma específica pelo Id."));

        // Atualiza o nome de uma turma específica pelo id utilizando o método PUT
        endpointsTurmas.MapPut("{id}", async (string id, PutTurmaRequest request, AppDbContext context) =>
        {
            var turma = await context.Turmas.FirstOrDefaultAsync(turma => turma.Id == id);

            if (turma == null)
            {
                return Results.NotFound();
            }

            turma.AtualizarNome(request.Nome_turma);
            await context.SaveChangesAsync();

            return Results.Ok(turma);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Atualiza uma turma", description: "Atualiza o nome de uma turma pelo Id."));

        // Deleta uma turma específica pelo id utilizando o método DELETE
        endpointsTurmas.MapDelete("{id}", async (string id, AppDbContext context) =>
        {
            var turma = await context.Turmas.FirstOrDefaultAsync(turma => turma.Id == id);

            if (turma == null)
            {
                return Results.NotFound();
            }

            context.Turmas.Remove(turma);
            await context.SaveChangesAsync();

            return Results.Ok();
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Deleta uma turma", description: "Deleta uma turma específica pelo Id."));
    }
}