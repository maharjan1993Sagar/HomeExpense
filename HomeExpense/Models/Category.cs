using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeExpense.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int SerialNo { get; set; } = 0;
        [Required]
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public String UpdatedBy { get; set; } = "Admin";
        public ICollection<Expense> Expenses { get; set; }
    }
}