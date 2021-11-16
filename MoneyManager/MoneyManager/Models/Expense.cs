using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Опис")]
        [MaxLength(50, ErrorMessage = "Максимальна кількість символів 50")]
        public string Description { get; set; }

        [DisplayName("Сума")]
        [Required(ErrorMessage = "Обов'язкове поле")]
        [Range(0, double.MaxValue, ErrorMessage = "Сума повинна бути більше 0.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [DisplayName("Дата")]
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        [DisplayName("Категорія витрат Id")]
        public int ExpenseTypeId { get; set; }

        [DisplayName("Категорія витрат")]
        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }
}