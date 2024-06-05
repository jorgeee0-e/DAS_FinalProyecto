using DAS_ProyectoFinal.Models;
using DAS_ProyectoFinal.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAS_ProyectoFinal.Controllers
{
    public class CarrerasNoticiasController : Controller
    {
        private readonly Iservicio_API _servicioAPI;
        public CarrerasNoticiasController(Iservicio_API servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }
        // GET: CarreraNoticiasController
        public async Task<ActionResult> Index()
        {
            var carreras = await _servicioAPI.Lista();
            var noticias= await _servicioAPI.ListaN();

            var viewModel = new CarrerasNoticias
            {
                Carreras = carreras,
                Noticias = noticias
            };
            return View(viewModel);
        }

        // GET: CarreraNoticiasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarreraNoticiasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarreraNoticiasController/Create
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

        // GET: CarreraNoticiasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarreraNoticiasController/Edit/5
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

        // GET: CarreraNoticiasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarreraNoticiasController/Delete/5
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
