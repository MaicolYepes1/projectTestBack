namespace ServicesAdministration.MODELS.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? ClientId { get; set; }
    }
}
