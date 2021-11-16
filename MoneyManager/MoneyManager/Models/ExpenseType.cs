using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [MaxLength(20, ErrorMessage = "Максимальна кількість символів 20")]
        public string Name { get; set; }

        public string UserId { get; set; }
    }
}
