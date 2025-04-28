using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Application.Common.Exceptions.WalletException
{
    public class WalletNotFoundException : Exception
    {
        public WalletNotFoundException(string message) : base(message) { }
    }

}
