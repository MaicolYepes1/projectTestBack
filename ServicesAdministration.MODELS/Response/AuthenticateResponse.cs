using ServicesAdministration.MODELS.Models;

namespace ServicesAdministration.MODELS.Response
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public AuthenticateResponse(UserModel user, string token)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Email = user.Email;
            AccessToken = token;
        }
    }
}
