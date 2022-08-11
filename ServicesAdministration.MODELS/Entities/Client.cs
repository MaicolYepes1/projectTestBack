namespace ServicesAdministration.MODELS.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public string? Identification { get; set; }
    }
}
