using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeExpense.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public String ItemName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public decimal Price { get; set; } = 0;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public String UpdatedBy { get; set; } = "Admin";
        public String NepaliDate { get; set; }
        public int MonthIndex { get; set; } = 0;
        public String ShortNote { get; set; }
    }
}