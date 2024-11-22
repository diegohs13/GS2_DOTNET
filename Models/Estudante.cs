namespace Gs2DotNet.Models;

public class Estudante
{
    public string Id { get; init; }
    public string Nome { get; private set; }
    public string Tipo { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }

    public Estudante(string id, string nome, string tipo, string email, string senha)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
        Email = email;
        Senha = senha;
    }

    public void AtualizarSenha(string senha)
    {
        Senha = senha;
    }
}