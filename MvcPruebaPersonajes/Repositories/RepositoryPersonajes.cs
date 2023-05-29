using Microsoft.EntityFrameworkCore;
using MvcPruebaPersonajes.Data;
using MvcPruebaPersonajes.Models;

namespace MvcPruebaPersonajes.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await
                this.context.Personajes
                .FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        private int GetMaxIdPersonaje()
        {
            return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
        }

        public async Task CreatePersonajeAsync(string nombre, string imagen)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxIdPersonaje();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync
            (int id, string nombre, string imagen)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            personaje.IdPersonaje = id;
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int id)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
