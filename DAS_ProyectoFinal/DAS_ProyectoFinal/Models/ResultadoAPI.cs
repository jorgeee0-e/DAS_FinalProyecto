using Newtonsoft.Json;

namespace DAS_ProyectoFinal.Models
{
    public class ResultadoAPI
    {
        [JsonProperty("mensaje")]
        public string mensaje { get; set; }

        [JsonProperty("response")]
        public List<Carreras> lista { get; set; }

        [JsonProperty("objeto")]
        public Carreras objeto { get; set; }
    }
}
