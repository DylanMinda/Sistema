using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alertas.Modelos
{
    public class Alerta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime fechaAlerta { get; set; }
        public Sensor? Sensor { get; set; }
        [ForeignKey("Sensor")]
        public int SensorId { get; set; }
    }
}
