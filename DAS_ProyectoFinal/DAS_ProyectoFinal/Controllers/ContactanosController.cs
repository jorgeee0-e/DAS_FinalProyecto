using DAS_ProyectoFinal.Models;
using DAS_ProyectoFinal.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAS_ProyectoFinal.Controllers
{

    public class ContactanosController : Controller
    {
        private readonly Iservicio_API _servicioAPI;
        public ContactanosController(Iservicio_API servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }
        

        // POST: ContactanosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GuardarC(ContactanosInput objeto)
        {
            bool respuesta;

            respuesta = await _servicioAPI.GuardarC(objeto);

               return View("GuardarC", respuesta);
            
        }
       
        }
    }
