using DAS_ProyectoFinal.Models;
using DAS_ProyectoFinal.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAS_ProyectoFinal.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly Iservicio_API _servicioAPI;
        public NoticiasController(Iservicio_API servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }
        // GET: NoticiasController1
        public async Task<IActionResult> Index()
        {
            List<Noticias> Lista = await _servicioAPI.ListaN();

            return View(Lista);
            
        }

    }
}
