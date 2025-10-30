namespace BSIT31A1_Mendoza_MarketPlace.Infrastructure
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string OwnerId { get; set; } = string.Empty; // Identity User Id
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Interest> Interests { get; set; } = new List<Interest>();
    }
}
