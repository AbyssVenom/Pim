using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim.Model
{
    public class ChamadoViewModel
    {
        // Vamos repetir as propriedades do Chamado
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public System.DateTime DataAbertura { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public string NomeSolicitante { get; set; }
        public string NomeTecnico { get; set; }
        public string AnexoPath { get; set; } // Caso queira mostrar se tem anexo
        public int UsuarioId { get; set; }    // Útil para saber se o usuário é dono do chamado
        public int? TecnicoId { get; set; }   // Útil para saber se já tem técnico

        // E adicionar a propriedade extra que queremos exibir
        public string CategoriaNome { get; set; }

        // (Também podemos formatar a data para exibição)
        public string DataFormatada => DataAbertura.ToString("dd/MM/yyyy");

        // (Podemos formatar o ID para ficar igual ao seu design TK-0001)
        public string IdFormatado => $"TK-{Id:D4}"; // "D4" = 4 dígitos com zeros à esquerda
    }
}
