namespace Bookmarted.Domain.ValueObjects
{
    public record Stock
    {
        public int Quantity { get; init; }

        public Stock(int quantity)
        {
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));
            Quantity = quantity;
        }

        public bool IsAvailable => Quantity > 0;
    }
}
