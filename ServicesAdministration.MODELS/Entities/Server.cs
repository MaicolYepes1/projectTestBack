namespace ServicesAdministration.MODELS.Entities
{
    public class Server
    {
        public int ServerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Ip { get; set; }
        public string? TotalCapacity { get; set; }
        public string? OccupiedCapacity { get; set; }
    }
}
