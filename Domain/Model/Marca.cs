using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Marca     {
        public int Id { get; set; }
        public String Nombre { get; set; }
        //Relacion uno a muchos con Vehiculo
        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
