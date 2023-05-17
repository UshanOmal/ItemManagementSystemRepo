using System.ComponentModel.DataAnnotations;

namespace ItemManagmentSystem.DTO
{
    public class AddItemDTO
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; } = null;
        public string Status { get; set; }
        public string Attachement { get; set; } = null;
    }
}
