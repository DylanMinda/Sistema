using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sistema.Modelos
{
    public class Mantenimiento
    {
        [Key] public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMantenimiento { get; set; }
        [ForeignKey("Taller")]
        public int TallerId { get; set; }
        [ForeignKey("Camion")]
        public int CamionId { get; set; }
        [JsonIgnore]
        public Taller? Taller { get; set; }
        [JsonIgnore]
        public Camion? Camion { get; set; }


    }
}
