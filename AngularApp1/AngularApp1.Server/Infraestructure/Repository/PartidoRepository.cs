using AngularApp1.Server.Domain.Entities;
using AngularApp1.Server.Domain.Interfaces;
using AngularApp1.Server.infraestructure.db;

namespace AngularApp1.Server.Infraestructure.Repository
{
    public class PartidoRepository : IPartidoRepository
    {

        public readonly ApplicationDbContext dbContext;

        public PartidoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Partido> CreateAsync(Partido entity)
        {
            throw new NotImplementedException();
        }

        public Task<Partido> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Partido>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
