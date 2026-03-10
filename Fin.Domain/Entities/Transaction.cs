using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fin.Domain.Enumerators;

namespace Fin.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public decimal Amoount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Installment { get; set; }
        public int InstallmentCount { get; set; }
        public Wallet Wallet { get; set; }
        public bool IsRecurring { get; set; }
        public TransactionType MyProperty { get; set; }
        public DateTime DueDate { get; set; }
        public  MyProperty { get; set; }
    }
}