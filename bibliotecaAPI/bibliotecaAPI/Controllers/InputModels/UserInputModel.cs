using System.ComponentModel.DataAnnotations;

namespace bibliotecaAPI.InputModels
{
    public class UserInputModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
