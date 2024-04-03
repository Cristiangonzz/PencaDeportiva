using AngularApp1.Server.Domain.Entities;

namespace AngularApp1.Server.Domain.Interfaces
{
    public interface ICampionatoRepository
    {
        Task<Campionato> CreateAsync(Campionato entity);
        Task<Campionato> GetAll();
        Task<List<Campionato>> GetById(Guid Id);
    }
}
