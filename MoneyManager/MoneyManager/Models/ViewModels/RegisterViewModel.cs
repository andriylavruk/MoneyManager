using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Пароль і пароль підтвердження не співпадають.")]
        public string ConfirmPassword { get; set; }
    }
}