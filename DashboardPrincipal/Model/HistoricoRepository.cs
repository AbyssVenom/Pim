using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Pim.Model
{
    public static class HistoricoRepository
    {
        public static void Salvar(Historico hist)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                string sql = "INSERT INTO Historico (ChamadoId, UsuarioId, Mensagem, DataHora) VALUES (@ChamadoId, @UsuarioId, @Mensagem, @DataHora)";
                connection.Execute(sql, hist);
            }
        }

        public static List<Historico> BuscarPorChamado(int chamadoId)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                // Traz o histórico JUNTANDO com a tabela de usuários para saber o nome de quem escreveu
                string sql = @"
                SELECT H.*, U.Nome AS NomeUsuario 
                FROM Historico H
                INNER JOIN Utilizadores U ON H.UsuarioId = U.Id
                WHERE H.ChamadoId = @ChamadoId
                ORDER BY H.DataHora ASC";

                return connection.Query<Historico>(sql, new { ChamadoId = chamadoId }).ToList();
            }
        }
    }
}
