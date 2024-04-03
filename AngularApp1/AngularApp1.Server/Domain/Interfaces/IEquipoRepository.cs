using AngularApp1.Server.Domain.Entities;
using System.Linq.Expressions;

namespace AngularApp1.Server.Domain.Interfaces
{
    public interface IEquipoRepository
    {
        Task<Equipo> Create(Equipo entity);
        Task<bool> Update(Equipo entity);

        Task<Equipo> Obtener(Expression<Func<Equipo, bool>> filtro = null);

        Task<bool> Delete(Equipo entidad);


        Task<IQueryable<Equipo>> Consultar(Expression<Func<Equipo, bool>> filtro = null);
    }
}
