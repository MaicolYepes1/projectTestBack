namespace ServicesAdministration.MODELS.Request
{
    public class ServerRequest
    {
        public int ServerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Ip { get; set; }
        public string? TotalCapacity { get; set; }
        public string? OccupiedCapacity { get; set; }
        public int ClientId { get; set; }
        public List<int>? Servicios { get; set; } = null;
    }
}
