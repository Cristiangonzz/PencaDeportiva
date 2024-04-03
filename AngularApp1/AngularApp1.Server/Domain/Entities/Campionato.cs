namespace AngularApp1.Server.Domain.Entities
{
    public class Campionato
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Equipo> Equipos { get; set; }
        public DateTime CreationDate { get; set;}

    }
}
