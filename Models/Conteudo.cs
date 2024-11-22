namespace Gs2DotNet.Models;

public class Conteudo
{
    public string Id { get; init; }
    public string Tipo { get; private set; }
    public string Descricao { get; private set; }

    public Conteudo(string id, string tipo, string descricao)
    {
        Id = id;
        Tipo = tipo;
        Descricao = descricao;
    }

    public void AtualizarDescricao(string descricao)
    {
        Descricao = descricao;
    }
}