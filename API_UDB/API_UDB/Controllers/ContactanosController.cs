using API_UDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace API_UDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactanosController : Controller
    {
        private readonly string cadenaSQL;
        
        public ContactanosController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Contactanos> lista = new List<Contactanos>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_listacontactos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using var rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        
                        lista.Add(new Contactanos()
                        {
                            Nombre = Convert.ToString(rd["nombre"]),
                            Email = Convert.ToString(rd["email"]),
                            Contact = Convert.ToString(rd["contact"]),
                            Consulta = Convert.ToString(rd["consulta"]),
                            Text = Convert.ToString(rd["text"]),
                            Id_contacto = Convert.ToString(rd["Id_contacto"]),
                            
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
        [Route("Obtener/{Id_Contacto}")]
        public IActionResult Obtener(String Id_Contacto)
        {
            List<Contactanos> lista = new List<Contactanos>();
            Contactanos contactanos = new Contactanos();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_listacontactos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using var rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {

                        lista.Add(new Contactanos()
                        {
                            Nombre = Convert.ToString(rd["nombre"]),
                            Email = Convert.ToString(rd["email"]),
                            Contact = Convert.ToString(rd["contact"]),
                            Consulta = Convert.ToString(rd["consulta"]),
                            Text = Convert.ToString(rd["text"]),
                            Id_contacto = Convert.ToString(rd["Id_contacto"]),

                        });
                    }

                }
                contactanos = lista.Where(item => item.Id_contacto== Id_Contacto).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = contactanos });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = contactanos});
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] ContactanosInput objeto)
        {

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_guardar_contacto", conexion);
                    cmd.Parameters.AddWithValue("nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("email", objeto.Email);
                    cmd.Parameters.AddWithValue("contact", objeto.Contact);
                    cmd.Parameters.AddWithValue("consulta", objeto.Consulta);
                    cmd.Parameters.AddWithValue("text", objeto.Text);
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
