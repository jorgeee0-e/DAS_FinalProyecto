using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace DAS_ProyectoFinal.Models
{
    public class Noticias
    {
        [Column("id_noticia")]

        [JsonProperty("id_noticia")]
        public String Id_noticia { get; set; }

        [Column("titulo")]

        [JsonProperty("titulo")]
        public String Titulo { get; set; }

        [Column("contenido")]

        [JsonProperty("contenido")]
        public String Contenido { get; set; }

        [Column("fecha_publicacion")]

        [JsonProperty("fecha_publicacion")]
        public SqlDateTime Fecha_publicacion { get; set; }

        [Column("id_carrera")]

        [JsonProperty("id_carrera")]
        public String Id_carrera { get; set; }

        [Column("imagen")]

        [JsonProperty("imagen")]
        public String Imagen { get; set; }

        public virtual ICollection<Carreras> Carreras { get; set; }

    }
}
