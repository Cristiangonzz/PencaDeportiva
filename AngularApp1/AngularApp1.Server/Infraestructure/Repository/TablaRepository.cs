using AngularApp1.Server.Domain.Entities;
using AngularApp1.Server.Domain.Interfaces;
using AngularApp1.Server.infraestructure.db;

namespace AngularApp1.Server.Infraestructure.Repository
{
    public class TablaRepository : ITablaRepository
    {

        public readonly ApplicationDbContext dbContext;

        public TablaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Tabla> CreateAsync(Tabla entity)
        {
            throw new NotImplementedException();
        }

        public Task<Tabla> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Tabla>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
