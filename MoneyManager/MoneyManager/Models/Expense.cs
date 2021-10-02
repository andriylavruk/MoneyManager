using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Назва")]
        [Required(ErrorMessage = "Обов'язкове поле")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string Name { get; set; }

        [DisplayName("Опис")]
        [MaxLength(50, ErrorMessage = "Максимальна кількість символів 50")]
        public string Description { get; set; }

        [DisplayName("Сума")]
        [Required(ErrorMessage = "Обов'язкове поле")]
        [Range(0, double.MaxValue, ErrorMessage = "Сума повинна бути більше 0.")]
        public double Amount { get; set; }

        [DisplayName("Категорія витрат")]
        public int ExpenseTypeId { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
