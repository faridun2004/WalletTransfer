using AutoMapper;
using SenderWaller.Domain.Entities;
using SenderWallet.Application.Common.DTOs.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SenderWallet.Application.Common.Mappers.Wallets
{
    public class WalletMappingProfile : Profile
    {
        public WalletMappingProfile()
        {
            CreateMap<Wallet, WalletDto>();
        }
    }

}
