using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWaller.Domain.Entities
{
    public class WalletTransaction
    {
        public Guid Id { get; set; }
        public Guid FromWalletId { get; set; }
        public Guid ToWalletId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

}
