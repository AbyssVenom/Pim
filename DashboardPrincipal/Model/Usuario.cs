using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; } // Armazenar hash, não senha em texto limpo!
        public string Tipo { get; set; } // "Admin", "Atendente", "Solicitante"
        public DateTime DataRegistro { get; set; }
        public string Telefone { get; set; }
        public string Departamento { get; set; }
        public string Bio { get; set; }
    }
}
