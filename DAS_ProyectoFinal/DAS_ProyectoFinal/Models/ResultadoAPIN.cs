using Newtonsoft.Json;

namespace DAS_ProyectoFinal.Models
{
    public class ResultadoAPIN
    {
        [JsonProperty("mensaje")]
        public string mensaje { get; set; }

        [JsonProperty("response")]
        public List<Noticias> listan { get; set; }

    }
}
