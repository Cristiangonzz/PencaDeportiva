using AngularApp1.Server.Domain.Entities;
using AngularApp1.Server.Domain.Interfaces;
using AngularApp1.Server.infraestructure.db;
using Microsoft.EntityFrameworkCore;

namespace AngularApp1.Server.Infraestructure.Repository
{
    public class CampionatoRepository : ICampionatoRepository
    {
        public readonly ApplicationDbContext dbContext;

        public CampionatoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Campionato> CreateAsync(Campionato entity)
        {
            try
            {
                dbContext.Set<Campionato>().Add(entity);
                await dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public Task<Campionato> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Campionato>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
