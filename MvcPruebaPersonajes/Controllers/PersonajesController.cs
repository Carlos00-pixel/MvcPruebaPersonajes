using Microsoft.AspNetCore.Mvc;
using MvcPruebaPersonajes.Models;
using MvcPruebaPersonajes.Repositories;

namespace MvcPruebaPersonajes.Controllers
{
    public class PersonajesController : Controller
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> GetPersonajes()
        {
            List<Personaje> personajes = await this.repo.GetPersonajesAsync();
            return View(personajes);
        }

        public async Task<IActionResult> Details(int id)
        {
            Personaje personaje = await this.repo.FindPersonajeAsync(id);
            return View(personaje);
        }

        public IActionResult InsertPersonaje()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertPersonaje(Personaje personaje)
        {
            await this.repo.CreatePersonajeAsync
                (personaje.Nombre, personaje.Imagen);
            return RedirectToAction("GetPersonajes");
        }

        public async Task<IActionResult> UpdatePersonaje(int id)
        {
            Personaje personaje = await this.repo.FindPersonajeAsync(id);
            return View(personaje);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonajeAsync
                (personaje.IdPersonaje, personaje.Nombre, personaje.Imagen);
            return RedirectToAction("GetPersonajes");
        }

        public async Task<IActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajeAsync(id);
            return RedirectToAction("GetPersonajes");
        }
    }
}
