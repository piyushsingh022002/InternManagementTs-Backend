namespace Backend.Models
{
    public class User
    {
        public int Id { get; set; }

        // Only required for Interns
        public string? InternId { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        // "HR" or "Intern"
        public string? Role { get; set; }
    }
}
