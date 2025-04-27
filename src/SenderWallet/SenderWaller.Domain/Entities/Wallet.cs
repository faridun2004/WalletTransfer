namespace SenderWaller.Domain.Entities
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public double UsdBalance { get; set; }
        public double TjsBalance { get; set; }
    }
}
