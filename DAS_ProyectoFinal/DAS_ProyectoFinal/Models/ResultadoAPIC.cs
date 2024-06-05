using Newtonsoft.Json;

namespace DAS_ProyectoFinal.Models
{
    public class ResultadoAPIC
    {
        [JsonProperty("mensaje")]
        public string mensaje { get; set; }

        [JsonProperty("response")]
        public List<ContactanosInput> lista { get; set; }
    }
}
