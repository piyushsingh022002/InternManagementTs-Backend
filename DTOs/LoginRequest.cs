// DTOs/LoginRequest.cs
namespace Backend.DTOs
{
    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? InternId { get; set; } // Optional for HR
        public string? Password { get; set; }
    }
}
