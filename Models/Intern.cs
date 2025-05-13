namespace Backend.Models
{
    public class Intern
    {
        public int Id { get; set; }
        public string? InternId { get; set; }  // Foreign key to User.InternId
        public string? Name { get; set; }
        public string? Domain { get; set; }
        public string? College { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
