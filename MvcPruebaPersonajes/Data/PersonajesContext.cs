using Microsoft.EntityFrameworkCore;
using MvcPruebaPersonajes.Models;
using System.Collections.Generic;

namespace MvcPruebaPersonajes.Data
{
    public class PersonajesContext : DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options)
            : base(options) { }

        public DbSet<Personaje> Personajes { get; set; }
    }
}
