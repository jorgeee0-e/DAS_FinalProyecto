using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAS_ProyectoFinal.Models
{
    public class Carreras
    {
        [Column("id_carrera")]

        [JsonProperty("id_carrera")]

        public String Id_carrera { get; set; }

        [Column("nombre_carrera")]

        [JsonProperty("nombre_carrera")]
        public String Nombre_carrera { get; set; }

        [Column("descripcion")]

        [JsonProperty("descripcion")]
        public String Descripcion { get; set; }

        [Column("duracion")]

        [JsonProperty("duracion")]
        public int Duracion { get; set; }

        [Column("nivel")]

        [JsonProperty("nivel")]
        public String Nivel { get; set; }

        [Column("requisitos")]

        [JsonProperty("requisitos")]
        public String Requisitos { get; set; }

        [Column("facultad")]

        [JsonProperty("facultad")]
        public String Facultad { get; set; }

        [Column("imagen")]

        [JsonProperty("imagen")]
        public byte[] Imagen { get; set; }

        public virtual Noticias Noticias { get; set; }
    }
}
