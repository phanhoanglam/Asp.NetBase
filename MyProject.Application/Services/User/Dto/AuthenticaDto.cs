namespace MyProject.Application.Services.User.Dto
{
    public class AuthenticaDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}