namespace AssetManagmentSystem2.Models
{
    public class Asset
    {
        public int Id { get; set; }

        public string Name { get; set;  }
        public double Cost { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
    }
}
