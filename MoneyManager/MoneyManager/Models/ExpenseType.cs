using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [MaxLength(20, ErrorMessage = "Максимальна кількість символів 20")]
        public string Name { get; set; }
    }
}
