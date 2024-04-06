namespace Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }


        public List<AppUserProduct> AppUserProducts { get; set; } = new List<AppUserProduct>();
    }
}
