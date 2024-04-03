namespace AngularApp1.Server.Domain.Entities
{
    public class Equipo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Activo { get; set; } = true;
    }
}
