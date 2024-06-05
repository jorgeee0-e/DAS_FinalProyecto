using API_UDB.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
namespace API_UDB.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerasController : ControllerBase
    {
        private readonly string cadenaSQL;
        public CarrerasController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Carreras> lista = new List<Carreras>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_lista_carreras", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using var rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        byte[] imgBytes = null;
                        if (!rd.IsDBNull(rd.GetOrdinal("imagen")) && rd["imagen"].GetType() == typeof(byte[]))
                        {
                            imgBytes = (byte[])rd["imagen"];
                        }
                        lista.Add(new Carreras()
                        {
                            Id_carrera = Convert.ToString(rd["id_carrera"]),
                            Nombre_carrera = Convert.ToString(rd["nombre_carrera"]),
                            Descripcion = Convert.ToString(rd["descripcion"]),
                            Duracion = Convert.ToInt32(rd["duracion"]),
                            Nivel = Convert.ToString(rd["nivel"]),
                            Requisitos = Convert.ToString(rd["requisitos"]),
                            Facultad = Convert.ToString(rd["facultad"]),
                            Imagen = imgBytes,


                        });
                    }

                }
                return StatusCode(StatusCodes.Status200OK,new { mensaje="ok",response=lista});
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{nombre_carrera}")] 
        public IActionResult Obtener(String nombre_carrera)
        {
            List<Carreras> lista = new List<Carreras>();
            Carreras carrera= new Carreras();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_lista_carreras", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using var rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        byte[] imgBytes = null;
                        if (!rd.IsDBNull(rd.GetOrdinal("imagen")) && rd["imagen"].GetType() == typeof(byte[]))
                        {
                            imgBytes = (byte[])rd["imagen"];
                        }
                        lista.Add(new Carreras()
                        {
                            Id_carrera = Convert.ToString(rd["id_carrera"]),
                            Nombre_carrera = Convert.ToString(rd["nombre_carrera"]),
                            Descripcion = Convert.ToString(rd["descripcion"]),
                            Duracion = Convert.ToInt32(rd["duracion"]),
                            Nivel = Convert.ToString(rd["nivel"]),
                            Requisitos = Convert.ToString(rd["requisitos"]),
                            Facultad = Convert.ToString(rd["facultad"]),
                            Imagen = imgBytes,


                        });
                    }

                }
                carrera = lista.Where(item => item.Nombre_carrera == nombre_carrera).FirstOrDefault(); 
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = carrera });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = carrera });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Carreras objeto)
        {

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_guardar_carrera", conexion);
                    cmd.Parameters.AddWithValue("id_carrera", objeto.Id_carrera);
                    cmd.Parameters.AddWithValue("nombre_carrera", objeto.Nombre_carrera);
                    cmd.Parameters.AddWithValue("descripcion", objeto.Descripcion);
                    cmd.Parameters.AddWithValue("duracion", objeto.Duracion);
                    cmd.Parameters.AddWithValue("nivel", objeto.Nivel);
                    cmd.Parameters.AddWithValue("requisitos", objeto.Requisitos);
                    cmd.Parameters.AddWithValue("facultad", objeto.Facultad);
                    if ( objeto.Imagen == null)
                    {
                        cmd.Parameters.Add("imagen", SqlDbType.VarBinary).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("imagen", objeto.Imagen);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    

                }
                
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message});
            }
        }

    }
}
