using System.ComponentModel.DataAnnotations;

namespace ItemManagmentSystem.DTO
{
    public class AddItem
    {
        [Required]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; } = null;

        [Required]
        public string Status { get; set; }
        public string Attachement { get; set; } = null;
    }
}
