namespace InternManagementAPI.DTOs
{
    public class CreateInternRequest
    {
        public string? Name { get; set; }
        public string? Domain { get; set; }
        public string? College { get; set; }
        public DateTime JoiningDate { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }  // HR sets it
    }
}
