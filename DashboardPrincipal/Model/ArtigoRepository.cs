using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Pim.Model
{
    public static class ArtigoRepository
    {
        public static List<Artigo> BuscarTodos(string termo = "")
        {
            using (var conn = DatabaseService.GetConnection())
            {
                string sql = "SELECT * FROM Artigos WHERE Titulo LIKE @Termo OR Categoria LIKE @Termo";
                return conn.Query<Artigo>(sql, new { Termo = $"%{termo}%" }).ToList();
            }
        }

        public static Artigo BuscarPorId(int id)
        {
            using (var conn = DatabaseService.GetConnection())
            {
                return conn.QueryFirstOrDefault<Artigo>("SELECT * FROM Artigos WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
