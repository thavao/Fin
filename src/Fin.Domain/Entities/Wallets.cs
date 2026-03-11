using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fin.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public decimal Limit { get; set; }
    }
}