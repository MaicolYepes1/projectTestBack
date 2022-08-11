﻿namespace ServicesAdministration.MODELS.Request
{
    public class UserRequest
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string? Email { get; set; }
        public int? ClientId { get; set; }
    }
}
