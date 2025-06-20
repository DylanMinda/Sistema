using System.ComponentModel.DataAnnotations.Schema;

namespace Alertas.Modelos
{
    public class Sensor
    {
        public int Id { get; set; }
        public double Kilometraje { get; set; } //camion kilometraje, fecha estadomotor
        public DateTime fechaRegistro { get; set; }
        public string estadoMotor { get; set; }

        [ForeignKey("Camion")] 
        public int CamionId { get; set; }
        public List<Alerta>?Alertas { get; set; }

    }
}
