using System.Data;

namespace AngularApp1.Server.Domain.Entities
{
    public class Tabla
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Campionato Campionato { get; set; }
        public List<Clasificacion> Clasificaciones { get; set; }
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
