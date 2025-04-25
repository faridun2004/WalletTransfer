using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Infrastrucrure.EntegrationEvents
{
    public class TransferRequestEvent
    {
        public Guid FromWalletId { get; set; }
        public Guid ToWalletId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Guid CorrelationId { get; set; }
    }

}
