using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Тип")]
        [Required(ErrorMessage = "Обов'язкове поле")]
        [MinLength(1, ErrorMessage = "Мінімальна кількість символів 1")]
        [MaxLength(20, ErrorMessage = "Максимальна кількість символів 20")]
        public string Name { get; set; }

        public string UserId { get; set; }
    }
}
