using API_UDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Cors;

namespace API_UDB.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : Controller
    {
        private readonly string cadenaSQL;

        public  NoticiasController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Noticias> lista = new List<Noticias>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_lista_noticias", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using var rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {

                        lista.Add(new Noticias()
                        {
                            Id_noticia = Convert.ToString(rd["id_noticia"]),
                            Titulo = Convert.ToString(rd["titulo"]),
                            Contenido = Convert.ToString(rd["contenido"]),
                            Fecha_publicacion =Convert.ToDateTime((rd["fecha_publicacion"])),
                            Id_carrera = Convert.ToString(rd["id_carrera"]),
                            Imagen = Convert.ToString(rd["imagen"]),
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
                        });
                    }

                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{titulo}")]
        public IActionResult Obtener(String titulo)
        {
            List<Noticias> lista = new List<Noticias>();
            Noticias noticia= new Noticias();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_lista_noticias", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using var rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                    
                        lista.Add(new Noticias()
                        {
                            Id_noticia = Convert.ToString(rd["id_noticia"]),
                            Titulo = Convert.ToString(rd["titulo"]),
                            Fecha_publicacion = Convert.ToDateTime((rd["fecha_publicacion"])),
                            Id_carrera = Convert.ToString(rd["id_carrera"]),
                            Imagen = Convert.ToString(rd["imagen"]),

                        });
                    }

                }
                noticia = lista.Where(item => item.Titulo == titulo).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = noticia });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = noticia });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Noticias objeto)
        {

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_guardar_noticia", conexion);
                    cmd.Parameters.AddWithValue("id", objeto.Id_noticia);
                    cmd.Parameters.AddWithValue("titulo", objeto.Titulo);
                    cmd.Parameters.AddWithValue("contenido", objeto.Contenido);
                    //string fechaString = objeto.Fecha_publicacion.ToString("yyyy-MM-dd");
                    //DateOnly fecha = DateOnly.Parse(fechaString);
                    //cmd.Parameters.AddWithValue("fecha_publicacion", fecha);

                    cmd.Parameters.AddWithValue("fecha_publicacion", objeto.Fecha_publicacion);
                    cmd.Parameters.AddWithValue("id_carrera", objeto.Id_carrera);
                    cmd.Parameters.AddWithValue("imagen", objeto.Imagen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }


    
}
}
