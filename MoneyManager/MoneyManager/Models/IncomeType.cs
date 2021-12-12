using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class IncomeType
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