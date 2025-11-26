
using System;
using System.Collections.Generic;

public class Chamado
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataAbertura { get; set; }
    public string Status { get; set; }
    public string Prioridade { get; set; }

    // Este é o ID da categoria (a chave estrangeira)

    public int CategoriaId { get; set; }
    public int UsuarioId { get; set; }    // Quem abriu
    public int? TecnicoId { get; set; }   // Quem atende (pode ser nulo)
    public string AnexoPath { get; set; } // O caminho do arquivo


}
