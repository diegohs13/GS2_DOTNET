

using Xunit;
using Gs2DotNet.Models;


public class ConteudoTests
{
    [Fact]
    public void Constructor_DeveInicializarCorretamente()
    {

        var conteudo = new Conteudo("1", "Video", "Descricao inicial");


        Assert.Equal("1", conteudo.Id);
        Assert.Equal("Video", conteudo.Tipo);
        Assert.Equal("Descricao inicial", conteudo.Descricao);
    }

    [Fact]
    public void AtualizarDescricao_DeveAlterarDescricaoCorretamente()
    {

        var conteudo = new Conteudo("1", "Video", "Descricao inicial");

        conteudo.AtualizarDescricao("Nova descricao");

        Assert.Equal("Nova descricao", conteudo.Descricao);
    }
}