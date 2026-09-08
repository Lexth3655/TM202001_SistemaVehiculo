using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Usuario
    {
        public String NombreCompleto { get; set; }
        public String Rol { get; set; }
        public bool Activo { get; set; }
    }
}
