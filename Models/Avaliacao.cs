namespace Gs2DotNet.Models;

public class Avaliacao
{
    public string Id { get; init; }
    public string Data { get; private set; }
    public string Pontuacao { get; private set; }

    public Avaliacao(string id, string data, string pontuacao)
    {
        Id = id;
        Data = data;
        Pontuacao = pontuacao;
    }

    public void AtualizarData(string data)
    {
        Data = data;
    }
}