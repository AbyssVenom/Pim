using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Pim.Model
{
    public static class CategoriaRepository
    {
        // Método para buscar todas as categorias
        public static List<Categoria> BuscarTodas()
        {
            // Abre uma conexão
            using (var connection = DatabaseService.GetConnection())
            {
                // Roda o SQL e o Dapper transforma o resultado em List<Categoria>
                return connection.Query<Categoria>("SELECT * FROM Categorias").ToList();
            }
        }

        // Método para salvar (Criar ou Atualizar)
        public static void Salvar(Categoria categoria)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                if (categoria.Id == 0) // Criar (Novo)
                {
                    // SQL para inserir e retornar o novo ID criado
                    string sql = "INSERT INTO Categorias (Nome, Descricao) VALUES (@Nome, @Descricao); " +
                                 "SELECT last_insert_rowid();";

                    // Dapper executa e retorna o ID
                    categoria.Id = connection.ExecuteScalar<int>(sql, categoria);
                }
                else // Atualizar (Editar)
                {
                    string sql = "UPDATE Categorias SET Nome = @Nome, Descricao = @Descricao WHERE Id = @Id";
                    connection.Execute(sql, categoria);
                }
            }
        }

        // Método para excluir
        public static void Excluir(Categoria categoria)
        {
            using (var connection = DatabaseService.GetConnection())
            {
                string sql = "DELETE FROM Categorias WHERE Id = @Id";
                connection.Execute(sql, new { Id = categoria.Id });
            }
        }
    }
}
