using System.ComponentModel.DataAnnotations;

namespace ItemManagmentSystem.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; } = null;

        [Required]
        public string Status { get; set; }
        public string Attachement { get; set; } = null;
    }
}
