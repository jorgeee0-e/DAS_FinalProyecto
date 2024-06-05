using DAS_ProyectoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAS_ProyectoFinal.Servicios
{
    public class Servicio_API : Iservicio_API

    {
        private static string _baseurl;
        public Servicio_API() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        
        public async Task<List<Carreras>> Lista()
        {
            List<Carreras> lista = new List<Carreras>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);
            
           var response = await cliente.GetAsync("/api/Carreras/Lista");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();


                var resultado = JsonConvert.DeserializeObject<ResultadoAPI>(json_respuesta);

                lista = resultado.lista;
            }
            return lista;

        }
        public async Task<Carreras> Obtener(string nombre_carrera)
        {
            Carreras objeto = new Carreras();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"/api/Carreras/Obtener/{nombre_carrera}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ResultadoAPI>(json_respuesta);

                objeto = resultado.objeto;
            }
            return objeto;

        }
        public async Task<bool> Guardar(Carreras objeto)
        {
            bool respuesta = false;
            
            var cliente = new HttpClient();
            
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto),Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("/api/Carreras/Guardar/",content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<List<Noticias>> ListaN()
        {
            List<Noticias> lista = new List<Noticias>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync("/api/Noticias/Lista");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ResultadoAPIN>(json_respuesta);

                lista = resultado.listan;
            }
            return lista;

        }

        public async Task<Noticias> ObtenerN(string titulo)
        {
            Noticias objeto = new Noticias();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"/api/Noticias/Obtener/{titulo}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ResultadoAPIN>(json_respuesta);

                objeto = resultado.listan.FirstOrDefault(n=>n.Titulo== titulo);
            }
            return objeto;

        }

        [HttpPost]
       public async Task<bool> GuardarC(ContactanosInput objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("/api/Contactanos/Guardar/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }





    }
}
