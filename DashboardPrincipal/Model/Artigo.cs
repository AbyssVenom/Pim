using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim.Model
{
    public class Artigo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Resumo { get; set; }
        public string Conteudo { get; set; } // O texto do artigo
        public DateTime DataAtualizacao { get; set; }
    }
}
