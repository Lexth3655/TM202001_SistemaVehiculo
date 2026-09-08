using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Venta
    {
        public int Id { get; set; }
        public decimal TotalVenta { get; set; }
        public int Cantidad { get; set; }

        public int? VehiculoId { get; set; } = 0;
        [JsonIgnore]
        public Vehiculo? Vehiculo { get; set; }

        
    }
}
