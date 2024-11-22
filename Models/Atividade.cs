namespace Gs2DotNet.Models;

public class Atividade
{
    public string Id { get; init; }
    public string Descricao { get; private set; }
    public string Tipo { get; private set; }

    public Atividade(string id, string descricao, string tipo)
    {
        Id = id;
        Descricao = descricao;
        Tipo = tipo;
    }

    public void AtualizarDescricao(string descricao)
    {
        Descricao = descricao;
    }
}