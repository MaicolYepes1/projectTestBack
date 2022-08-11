namespace ServicesAdministration.MODELS.Request
{
    public class ClientRequest
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public string? Identification { get; set; }
    }
}
