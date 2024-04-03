using AngularApp1.Server.Domain.Entities;

namespace AngularApp1.Server.Domain.Interfaces
{
    public interface ITablaRepository
    {
        Task<Tabla> CreateAsync(Tabla entity);
        Task<Tabla> GetAll();
        Task<List<Tabla>> GetById(Guid Id);
    }
}
