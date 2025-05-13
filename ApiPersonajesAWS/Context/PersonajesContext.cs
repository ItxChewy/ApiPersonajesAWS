using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Context
{
    public class PersonajesContext:DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext>options)
            : base(options) { }

        public DbSet<Personaje> Personajes { get; set; }
    }
}
