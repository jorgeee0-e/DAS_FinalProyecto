using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace API_UDB.Models
{
    public class Noticias
    {
        [Column("id_noticia")]
        public String Id_noticia { get; set; }

        [Column("titulo")]
        public String Titulo { get; set; }
        
        [Column("contenido")]
        public String Contenido { get; set; }

        [Column("fecha_publicacion")]
        public SqlDateTime Fecha_publicacion { get; set; }

        [Column("id_carrera")]
        public String Id_carrera { get; set; }

        [Column("imagen")]
        public String Imagen { get; set; }



    }
}
