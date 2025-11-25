using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace Pim.Model
{
    public static class UsuarioRepository
    {
        // Salva ou atualiza um usuário
        public static void Salvar(Usuario usuario)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                if (usuario.Id == 0) // Novo usuário
                {
                    string sql = @"
                    INSERT INTO Utilizadores (Nome, Email, SenhaHash, Tipo, DataRegistro)
                    VALUES (@Nome, @Email, @SenhaHash, @Tipo, @DataRegistro);
                    SELECT last_insert_rowid();";
                    usuario.Id = connection.ExecuteScalar<int>(sql, usuario);
                }
                else // Atualizar usuário existente
                {
                    string sql = @"
                    UPDATE Utilizadores SET
                        Nome = @Nome,
                        Email = @Email,
                        SenhaHash = @SenhaHash,
                        Tipo = @Tipo
                    WHERE Id = @Id";
                    connection.Execute(sql, usuario);
                }
            }
        }

        // Busca um usuário pelo ID
        public static Usuario BuscarPorId(int id)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                return connection.QueryFirstOrDefault<Usuario>("SELECT * FROM Utilizadores WHERE Id = @Id", new { Id = id });
            }
        }

        // Busca um usuário pelo Email
        public static Usuario BuscarPorEmail(string email)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                return connection.QueryFirstOrDefault<Usuario>("SELECT * FROM Utilizadores WHERE Email = @Email", new { Email = email });
            }
        }

        // Retorna todos os usuários
        public static List<Usuario> BuscarTodos()
        {
            using (var connection = DatabaseService.GetConnection())
            {
                return connection.Query<Usuario>("SELECT * FROM Utilizadores").ToList();
            }
        }
        public static List<Usuario> BuscarAtendentes()
        {
            using (var conn = DatabaseService.GetConnection())
            {
                // Busca Admin ou Atendente
                return conn.Query<Usuario>("SELECT * FROM Utilizadores WHERE Tipo IN ('Admin', 'Atendente')").ToList();
            }
        }

        // Autentica um usuário (verifica email e senha)
        public static Usuario Autenticar(string email, string senha)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                var usuario = connection.QueryFirstOrDefault<Usuario>(
                    "SELECT * FROM Utilizadores WHERE Email = @Email",
                    new { Email = email }
                );

                if (usuario != null)
                {
                    // Compara o hash da senha fornecida com o hash salvo
                    string senhaHashInput = DatabaseService.HashSenhaSimples(senha); // Usa o mesmo método de hash
                    if (usuario.SenhaHash == senhaHashInput)
                    {
                        return usuario; // Sucesso na autenticação
                    }
                }
                return null; // Falha na autenticação
            }
        }

        // Exclui um usuário
        public static void Excluir(int id)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                connection.Execute("DELETE FROM Utilizadores WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
