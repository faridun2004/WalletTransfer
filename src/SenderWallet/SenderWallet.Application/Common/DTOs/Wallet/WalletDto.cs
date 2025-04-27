using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Application.Common.DTOs.Wallet
{
    public class WalletDto
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public double USDBalance {  get; set; }
        public double TJSBalance { get; set; }

    }
}
