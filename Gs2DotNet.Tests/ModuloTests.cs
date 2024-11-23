using Xunit;
using Gs2DotNet.Models;

namespace Gs2DotNet.Tests;

public class ModuloTests
{
    [Fact]
    public void Constructor_DeveInicializarCorretamente()
    {

        var modulo = new Modulo("1", "Matemática", "Descrição inicial", "Intermediário");


        Assert.Equal("1", modulo.Id);
        Assert.Equal("Matemática", modulo.Titulo);
        Assert.Equal("Descrição inicial", modulo.Descricao);
        Assert.Equal("Intermediário", modulo.Nivel);
    }

    [Fact]
    public void AtualizarDescricao_DeveAlterarDescricaoCorretamente()
    {

        var modulo = new Modulo("1", "Matemática", "Descrição inicial", "Intermediário");


        modulo.AtualzarDescricao("Nova descrição");


        Assert.Equal("Nova descrição", modulo.Descricao);
    }
}