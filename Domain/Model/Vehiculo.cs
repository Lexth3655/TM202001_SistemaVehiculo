using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string CantidadPuertas { get; set; }


        //Clave foranea a Marca
        public int MarcaId { get; set; }
        [JsonIgnore]
        public Marca? Marca { get; set; }

        //Clave foranea a Venta (nullable porque un vehiculo puede no estar vendido)
        [JsonIgnore]
        public int? VentaId { get; set; }
        [JsonIgnore]
        public Venta? Venta { get; set; }
    }
}
