namespace Gs2DotNet.Models;

public class Modulo
{
    public string Id { get; init; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string Nivel { get; private set; }

    public Modulo(string id, string titulo, string descricao, string nivel)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Nivel = nivel;
    }

    public void AtualzarDescricao(string descricao)
    {
        Descricao = descricao;
    }
}