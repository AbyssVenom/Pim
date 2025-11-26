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
                INSERT INTO Utilizadores (Nome, Email, SenhaHash, Tipo, DataRegistro, Telefone, Departamento, Bio)
                VALUES (@Nome, @Email, @SenhaHash, @Tipo, @DataRegistro, @Telefone, @Departamento, @Bio);
                SELECT last_insert_rowid();";
                    usuario.Id = connection.ExecuteScalar<int>(sql, usuario);
                }
                else // Atualizar usuário existente
                {
                    string sql = @"
                UPDATE Utilizadores SET
                    Nome = @Nome,
                    Email = @Email,
                    Tipo = @Tipo,
                    Telefone = @Telefone,
                    Departamento = @Departamento,
                    Bio = @Bio
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
        public static void AtualizarPerfil(Usuario u)
        {
            using (var conn = DatabaseService.GetConnection())
            {
                string sql = @"
            UPDATE Utilizadores SET 
                Nome = @Nome, 
                Telefone = @Telefone, 
                Departamento = @Departamento, 
                Bio = @Bio 
            WHERE Id = @Id";
                conn.Execute(sql, u);
            }
        }
        public static void AlterarSenha(int id, string novaSenhaHash)
        {
            using (var conn = DatabaseService.GetConnection())
            {
                string sql = "UPDATE Utilizadores SET SenhaHash = @SenhaHash WHERE Id = @Id";
                conn.Execute(sql, new { SenhaHash = novaSenhaHash, Id = id });
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
