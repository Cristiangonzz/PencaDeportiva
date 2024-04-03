using AngularApp1.Server.Domain.Entities;

namespace AngularApp1.Server.Domain.Interfaces
{
    public interface IPartidoRepository
    {
        Task<Partido> CreateAsync(Partido entity);
        Task<Partido> GetAll();
        Task<List<Partido>> GetById(Guid Id);
    }
}
