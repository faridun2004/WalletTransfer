using MediatR;
using SenderWaller.Domain.Entities;
using SenderWallet.Application.Data;

namespace SenderWallet.Application.UseCases.Wallets.CreateWallet
{
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, Wallet>
    {
        private readonly IWalletDbContext _dbContext;

        public CreateWalletCommandHandler(IWalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Wallet> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = new Wallet
            {
                Id = Guid.NewGuid(),
                Owner = request.Owner,
                Balance = 1000
            };
            _dbContext.Wallets.Add(wallet);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return wallet;
        }
    }
}