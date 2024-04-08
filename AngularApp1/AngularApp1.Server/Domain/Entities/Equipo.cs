namespace AngularApp1.Server.Domain.Entities
{
    public class Equipo
    {
        public Guid id { get; set; }
        public string name { get; set; }

        public bool activo { get; set; } = true;
    }
}
