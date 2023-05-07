using System.ComponentModel.DataAnnotations;

namespace MoqProject.API.Models
{
    public class Contact
    {
        [Key]
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
