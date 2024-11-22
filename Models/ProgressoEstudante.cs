namespace Gs2DotNet.Models;

public class ProgressoEstudante
{
    public string Id { get; init; }
    public string Data_inicio { get; private set; }
    public string Data_fim { get; private set; }
    public string Pontuacao_final { get; private set; }

    public ProgressoEstudante(string id, string data_inicio, string data_fim, string pontuacao_final)
    {
        Id = id;
        Data_inicio = data_inicio;
        Data_fim = data_fim;
        Pontuacao_final = pontuacao_final;
    }

    public void AtualizarPontuacao(string pontuacao_final)
    {
        Pontuacao_final = pontuacao_final;
    }
}