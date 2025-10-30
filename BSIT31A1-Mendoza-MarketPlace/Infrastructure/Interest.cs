namespace BSIT31A1_Mendoza_MarketPlace.Infrastructure
{
    public class Interest
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string BuyerId { get; set; } = string.Empty; // Identity User Id
        public DateTime InterestedAt { get; set; } = DateTime.UtcNow;

        public Item? Item { get; set; }
    }
}
