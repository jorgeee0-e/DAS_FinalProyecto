using DAS_ProyectoFinal.Models;
using DAS_ProyectoFinal.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAS_ProyectoFinal.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly Iservicio_API _servicioAPI;
        public CarrerasController(Iservicio_API servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }
        // GET: CarrerasController
        public async Task<IActionResult> Index()
        {
            List<Carreras> Lista = await _servicioAPI.Lista();
            return View(Lista);
        }

        public async Task<IActionResult> Carrera(string nombre_carrera)
        {
            Carreras carrera = new Carreras();
            ViewBag.Accion = "Nueva Carrera";
            if (nombre_carrera != null || nombre_carrera!="")
            {
                carrera = await _servicioAPI.Obtener(nombre_carrera);
            }
            
            return View(carrera);
        }

        // GET: CarrerasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarrerasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarrerasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarrerasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarrerasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarrerasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarrerasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
