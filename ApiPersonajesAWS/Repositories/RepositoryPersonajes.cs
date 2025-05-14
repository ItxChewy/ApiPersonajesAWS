using ApiPersonajesAWS.Context;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Repositories
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

        public async Task<Personaje>GetPersonajeAsync(int id)
        {
            return await this.context.Personajes
                .FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        public async Task<int> GetMaxIdAsync()
        {
            return await this.context.Personajes.MaxAsync(x => x.IdPersonaje) + 1;
        }

        public async Task CreatePersonajesAsync(string nombre, string imagen)
        {
            Personaje p = new Personaje();
            p.IdPersonaje = await this.GetMaxIdAsync();
            p.Nombre = nombre;
            p.Imagen = imagen;
            await this.context.Personajes.AddAsync(p);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int id,string nombre,string imagen)
        {
            Personaje personaje = await this.GetPersonajeAsync(id);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            await this.context.SaveChangesAsync();
        }
    }

}
