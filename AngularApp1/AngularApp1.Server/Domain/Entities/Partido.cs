namespace AngularApp1.Server.Domain.Entities
{
    public class Partido
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GolLocal { get; set; } = 0;
        public int GolVisitante { get; set; } = 0;
        public List<Equipo> Equipos { get; set; }
    }
}
