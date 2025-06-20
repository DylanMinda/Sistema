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
    public class Camion
    {
        [Key] public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string Placa { get; set; }
        public int Kilometraje { get; set; }
        public string Estado { get; set; }
        [ForeignKey("Conductor")]
        public int ConductorId { get; set; }
        [JsonIgnore]
        public Conductor? Conductor { get; set; }
        [JsonIgnore]
        public List<Mantenimiento>? mantenimientos { get; set; }
    }
}
