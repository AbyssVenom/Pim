using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim.Model
{
    public class Historico
    {
        public int Id { get; set; }
        public int ChamadoId { get; set; }
        public int UsuarioId { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHora { get; set; }

        // Propriedade extra para exibir o nome de quem comentou (via JOIN)
        public string NomeUsuario { get; set; }

        // Formatação da data para exibir na tela
        public string DataFormatada => DataHora.ToString("dd/MM/yyyy HH:mm");
    }
}
