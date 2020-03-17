namespace MyProject.Application.Services.User.Dto
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
    }
}