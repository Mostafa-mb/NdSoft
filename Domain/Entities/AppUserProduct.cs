namespace Domain.Entities
{
    public class AppUserProduct
    {
        public string AppUserId { get; set; }
        public long ProductId { get; set; }
        public AppUser AppUser { get; set; }
        public Product product { get; set; }
    }
}
