using Gs2DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace Gs2DotNet.Data;

public class AppDbContext : DbContext
{
    public DbSet<Conteudo> Conteudos {get; set;}
    public DbSet<Estudante> Estudantes { get; set; }
    public DbSet<Modulo> Modulos { get; set; }
    public DbSet<Turma> Turmas { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //String de conexão com o banco de dados Oracle
        optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) " +
                                 "(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=rm550269;Password=291103;");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configuração das tabelas
        modelBuilder.Entity<Conteudo>().ToTable("tb_conteudo");
        modelBuilder.Entity<Estudante>().ToTable("tb_estudante");
        modelBuilder.Entity<Modulo>().ToTable("tb_modulo");
        modelBuilder.Entity<Turma>().ToTable("tb_turma");
        
        //Configuração das chaves primárias
        modelBuilder.Entity<Conteudo>().HasKey(conteudo => conteudo.Id);
        modelBuilder.Entity<Estudante>().HasKey(estudante => estudante.Id);
        modelBuilder.Entity<Modulo>().HasKey(modulo => modulo.Id);
        modelBuilder.Entity<Turma>().HasKey(turma => turma.Id);
    }
}