using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Modelos
{
    public class Conductor
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public List<Camion>? Camiones { get; set; } 

    }
}
