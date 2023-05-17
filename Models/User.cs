using System.ComponentModel.DataAnnotations;

namespace ItemManagmentSystem.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; } = null;
    }
}
