namespace Bookmarted.Domain.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "EGP";

        public Money(decimal amount, string currency = "EGP")
        {
            if (amount < 0) throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            Amount = amount;
            Currency = currency;
        }

        public override string ToString() => $"{Amount} {Currency}";
    }
}
