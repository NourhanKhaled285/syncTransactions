using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SyncTransactions.Models
{
    public class TransactionViewModel
    {
        [Key]
        public int TransactionId { get; set; } 

        public int CategoryId { get; set; } 
        public int Amount { get; set; }
        [Column(TypeName = "nvarchar(75)")]
        public string Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
