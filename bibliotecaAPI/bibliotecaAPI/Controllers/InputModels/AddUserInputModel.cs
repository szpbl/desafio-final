using System.ComponentModel.DataAnnotations;

namespace bibliotecaAPI.InputModels
{
    public class AddUserInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
