using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Events
{
    public record WalletTransferedEvent(
        Guid WalletId,
        double Amount,
        WalletStatus CurrencyFrom,
        WalletStatus CurrencyTo,
        Guid WalletSentId
    );
}
