namespace Gs2DotNet.Models;

public class Turma
{
    public string Id { get; init; }
    public string Nome_turma { get; private set; }
    public string Ano { get; private set; }

    public Turma(string id, string nome_turma, string ano)
    {
        Id = id;
        Nome_turma = nome_turma;
        Ano = ano;
    }

    public void AtualizarNome(string nome_turma)
    {
        Nome_turma = nome_turma;
    }
}