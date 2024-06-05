using System.ComponentModel.DataAnnotations.Schema;

namespace DAS_ProyectoFinal.Models
{
    public class ContactanosInput
    {
        [Column("nombre")]
        public String Nombre { get; set; }

        [Column("email")]
        public String Email { get; set; }

        [Column("contact")]
        public String Contact { get; set; }

        [Column("consulta")]
        public String Consulta { get; set; }

        [Column("text")]
        public String Text { get; set; }
    }
}
