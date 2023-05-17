using System.ComponentModel.DataAnnotations;

namespace ItemManagmentSystem.DTO
{
    public class AddUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; } = null;
    }
}
