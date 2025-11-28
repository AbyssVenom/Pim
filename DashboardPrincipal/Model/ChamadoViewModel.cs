using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim.Model
{
    public class ChamadoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public System.DateTime DataAbertura { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public string NomeSolicitante { get; set; }
        public string NomeTecnico { get; set; }
        public string AnexoPath { get; set; } 
        public int UsuarioId { get; set; } 
        public int? TecnicoId { get; set; } 

        public string CategoriaNome { get; set; }

        public string DataFormatada => DataAbertura.ToString("dd/MM/yyyy");
        public string IdFormatado => $"TK-{Id:D4}"; 
    }
}
