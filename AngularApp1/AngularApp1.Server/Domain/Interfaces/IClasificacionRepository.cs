using AngularApp1.Server.Domain.Entities;

namespace AngularApp1.Server.Domain.Interfaces
{
    public interface IClasificacionRepository
    {
        Task<Clasificacion> CreateAsync(Clasificacion entity);
        Task<Clasificacion> GetAll();
        Task<List<Clasificacion>> GetById(Guid Id);
    }
}
