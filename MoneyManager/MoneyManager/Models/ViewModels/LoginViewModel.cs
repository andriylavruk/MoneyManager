using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обов'язкове поле")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати мене")]
        public bool RememberMe { get; set; }
    }
}
