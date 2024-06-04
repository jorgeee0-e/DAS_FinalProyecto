using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_UDB.Models
{
    public class Carreras
    {
        [Column("id_carrera")]
        public String Id_carrera { get; set; }

        [Column("nombre_carrera")]
        public String Nombre_carrera { get; set; }

        [Column("descripcion")]
        public String Descripcion { get; set; }

        [Column("duracion")]
        public int Duracion { get; set; }

        [Column("nivel")]
        public String Nivel { get; set; }

        [Column("requisitos")]
        public String Requisitos { get; set; }

        [Column("facultad")]
        public String Facultad { get; set; }

        [Column("imagen")]
        public byte[] Imagen { get; set; }

    }
}


