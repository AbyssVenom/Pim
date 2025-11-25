using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Pim.Model
{
    public static class ChamadoRepository
    {
        public static void Salvar(Chamado chamado)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                // (Assumimos que só estamos criando novos por enquanto)
                string sql = @"
                INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, Prioridade, CategoriaId)
                VALUES (@Titulo, @Descricao, @DataAbertura, @Status, @Prioridade, @CategoriaId)";

                connection.Execute(sql, chamado);
            }
        }
        public static void AtualizarStatus(int chamadoId, string novoStatus)
        {
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Execute("UPDATE Chamados SET Status = @Status WHERE Id = @Id", new { Status = novoStatus, Id = chamadoId });
            }
        }

        public static void AtualizarPrioridade(int chamadoId, string novaPrioridade)
        {
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Execute("UPDATE Chamados SET Prioridade = @Prioridade WHERE Id = @Id", new { Prioridade = novaPrioridade, Id = chamadoId });
            }
        }
        public static List<ChamadoViewModel> BuscarComFiltros(string termo, string status, int? usuarioId = null)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                // Começamos com o SQL básico (JOINs)
                string sql = @"
            SELECT
                T1.Id, T1.Titulo, T1.Descricao, T1.DataAbertura, T1.Status, T1.Prioridade, T1.AnexoPath,
                C.Nome AS CategoriaNome,
                U.Nome AS NomeSolicitante
            FROM Chamados AS T1
            LEFT JOIN Categorias AS C ON T1.CategoriaId = C.Id
            LEFT JOIN Utilizadores AS U ON T1.UsuarioId = U.Id
            WHERE 1=1 "; // O 'WHERE 1=1' é um truque para facilitar adicionar 'ANDs' depois

                // --- Filtro Dinâmico ---

                // 1. Filtro por Texto (Título ou ID formatado)
                if (!string.IsNullOrWhiteSpace(termo))
                {
                    // Se o usuário digitou "TK-005", extraímos só o 5
                    string termoLimpo = termo.ToUpper().Replace("TK-", "").Trim();

                    // Pesquisa no Título OU no ID
                    sql += " AND (T1.Titulo LIKE @Termo OR T1.Id = @IdBusca) ";
                }

                // 2. Filtro por Status
                if (!string.IsNullOrWhiteSpace(status) && status != "Todos")
                {
                    sql += " AND T1.Status = @Status ";
                }

                // 3. Filtro por Usuário (Se for Solicitante, só vê os dele)
                if (usuarioId != null)
                {
                    sql += " AND T1.UsuarioId = @UsuarioId ";
                }

                sql += " ORDER BY T1.Id DESC";

                // Preparar os parâmetros para evitar SQL Injection
                var parametros = new DynamicParameters();
                parametros.Add("@Termo", $"%{termo}%"); // O % é para buscar partes do texto

                // Tenta converter o termo para int para buscar por ID. Se falhar, busca ID -1 (nada)
                int idBusca = 0;
                int.TryParse(termo.ToUpper().Replace("TK-", ""), out idBusca);
                parametros.Add("@IdBusca", idBusca);

                parametros.Add("@Status", status);
                parametros.Add("@UsuarioId", usuarioId);

                return connection.Query<ChamadoViewModel>(sql, parametros).ToList();
            }
        }
        public static void AtribuirAtendente(int chamadoId, int? atendenteId) // int? aceita null
        {
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Execute("UPDATE Chamados SET TecnicoId = @TecnicoId WHERE Id = @Id", new { TecnicoId = atendenteId, Id = chamadoId });
            }
            // OBS: Certifique-se que sua tabela Chamados tem a coluna 'TecnicoId'. 
            // Se você chamou de outra coisa no DatabaseService (ex: AtendenteId), mude aqui.
        }

        // Busca todos os chamados
        public static List<ChamadoViewModel> BuscarTodosViewModel()
        {
            using (var connection = DatabaseService.GetConnection())
            {
                // Este é o SQL com JOIN.
                // Ele "junta" a tabela Chamados (T1) com a tabela Categorias (T2)
                // onde T1.CategoriaId é igual a T2.Id
                string sql = @"
            SELECT
                T1.Id,
                T1.Titulo,
                T1.Descricao,
                T1.DataAbertura,
                T1.Status,
                T1.Prioridade,
                T2.Nome AS CategoriaNome  -- Pega o Nome da Categoria                                                                           
            FROM
                Chamados AS T1
            INNER JOIN
                Categorias AS T2 ON T1.CategoriaId = T2.Id
            ORDER BY
                T1.Id DESC"; // Ordena pelos mais recentes

                // O Dapper magicamente preenche a List<ChamadoViewModel>
                return connection.Query<ChamadoViewModel>(sql).ToList();
            }
        }
        public static ChamadoViewModel BuscarPorId(int id)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                string sql = @"
            SELECT
                T1.Id,
                T1.Titulo,
                T1.Descricao,
                T1.DataAbertura,
                T1.Status,
                T1.Prioridade,
                T1.AnexoPath,
                T1.UsuarioId,   -- Precisamos do ID para logica
                T1.TecnicoId,
                C.Nome AS CategoriaNome, -- Nome da Categoria
                U.Nome AS NomeSolicitante, -- Nome de quem abriu (JOIN com tabela usuarios)
                T.Nome AS NomeTecnico      -- Nome do tecnico (JOIN com tabela usuarios de novo)
            FROM
                Chamados AS T1
            LEFT JOIN
                Categorias AS C ON T1.CategoriaId = C.Id
            LEFT JOIN
                Utilizadores AS U ON T1.UsuarioId = U.Id
            LEFT JOIN
                Utilizadores AS T ON T1.TecnicoId = T.Id
            WHERE
                T1.Id = @Id";

                return connection.QueryFirstOrDefault<ChamadoViewModel>(sql, new { Id = id });
            }
        }
    }
}
