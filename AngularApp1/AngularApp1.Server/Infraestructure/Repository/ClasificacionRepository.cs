using AngularApp1.Server.Domain.Entities;
using AngularApp1.Server.Domain.Interfaces;
using AngularApp1.Server.infraestructure.db;

namespace AngularApp1.Server.Infraestructure.Repository
{
    public class ClasificacionRepository : IClasificacionRepository
    {

        public readonly ApplicationDbContext dbContext;

        public ClasificacionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Clasificacion> CreateAsync(Clasificacion entity)
        {
            throw new NotImplementedException();
        }

        public Task<Clasificacion> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Clasificacion>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
