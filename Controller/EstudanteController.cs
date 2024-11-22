using Gs2DotNet.Data;
using Gs2DotNet.Models;
using Gs2DotNet.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Gs2DotNet.Controller;

public static class EstudanteController
{
    public static void MapEndpointsEstudante(this WebApplication app)
    {
        var endpointsEstudantes = app.MapGroup("estudantes");
        
        // Adiciona um novo estudante no banco de dados utilizando o método POST
        endpointsEstudantes.MapPost("", async (AddEstudanteRequest request, AppDbContext context) =>
            {
                var verificacao = await context.Estudantes.
                    FirstOrDefaultAsync(estudante => estudante.Id == request.Id);

                if (verificacao != null)
                {
                    return Results.Conflict("Já existe um estudante com esse ID.");
                }

                var novoEstudante = new Estudante(request.Id, request.Nome, 
                    request.Tipo, request.Email, request.Senha);

                await context.Estudantes.AddAsync(novoEstudante);
                await context.SaveChangesAsync();

                return Results.Ok(novoEstudante);
            })
            .WithMetadata(new SwaggerOperationAttribute(summary: "Cria um novo estudante ", description: "Adiciona um estudante ao banco de dados."));
        
        
        // Retorna um estudante específico pelo Id utilizando o método GET
        endpointsEstudantes.MapGet("{id}", async (string id, AppDbContext context) =>
        {
            var estudante = await context.Estudantes.FirstOrDefaultAsync(estudante => estudante.Id == id);
            return estudante == null ? Results.NotFound() : Results.Ok(estudante);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Obtem um estudante", description: "Retorna um estudante específico pelo Id."));

        // Atualiza a senha de um estudante específico pelo Id utilizando o método PUT
        endpointsEstudantes.MapPut("{id}", async (string id, PutEstudanteRequest request, AppDbContext context) =>
        {
            var estudante = await context.Estudantes.FirstOrDefaultAsync(estudante => estudante.Id == id);

            if (estudante == null)
            {
                return Results.NotFound();
            }

            estudante.AtualizarSenha(request.Senha);
            await context.SaveChangesAsync();
            return Results.Ok(estudante);
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Atualiza um estudante", description: "Atualiza a senha de um estudante pelo ID."));

        // Deleta um estudante específico pelo Id utilizando o método DELETE
        endpointsEstudantes.MapDelete("{id }", async (string id, AppDbContext context) =>
        {
            var estudante = await context.Estudantes.FirstOrDefaultAsync(estudante => estudante.Id == id);

            if (estudante == null)
            {
                return Results.NotFound();
            }

            context.Estudantes.Remove(estudante);
            await context.SaveChangesAsync();
            return Results.Ok();
        })
        .WithMetadata(new SwaggerOperationAttribute(summary: "Deleta um estudante", description: "Deleta um estudante específico pelo Id."));
    } 
    
    
}