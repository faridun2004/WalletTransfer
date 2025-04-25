using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWaller.Domain.Entities
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public string Owner { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }

}
