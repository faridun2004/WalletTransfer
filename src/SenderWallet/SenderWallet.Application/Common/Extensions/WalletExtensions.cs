using Contracts.Events;
using SenderWaller.Domain.Entities;
using SenderWallet.Application.Common.Exceptions.WalletException;
using SenderWallet.Application.UseCases.Wallets.Commands.ExchangeCurrencyWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Application.Common.Extensions
{
    public static class WalletExtensions
    {
        public static void ValidateSufficientBalance(this Wallet wallet, WalletStatus currency, double amount)
        {
            if (currency == WalletStatus.USD && wallet.UsdBalance < amount)
                throw new InsufficientBalanceException("Insufficient USD balance.");

            if (currency == WalletStatus.TJS && wallet.TjsBalance < amount)
                throw new InsufficientBalanceException("Insufficient TJS balance.");
        }

        public  static void PerformCurrencyExchange(this Wallet sender, Wallet receiver, ExchangeCurrencyCommand request)
        {
            if (request.CurrencyFrom == WalletStatus.USD)
                sender.UsdBalance -= request.Amount;
            else
                sender.TjsBalance -= request.Amount;

            if (request.CurrencyTo == WalletStatus.USD)
                receiver.UsdBalance += request.Amount;
            else
                receiver.TjsBalance += request.Amount;
        }
    }
}
