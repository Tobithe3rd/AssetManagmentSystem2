using System.ComponentModel.DataAnnotations;
namespace AssetManagmentSystem2.Models
{
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set;  }
        [Required]
    public double Cost { get; set; }
        [Required]
    public DateTime DateOfPurchase { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
    }
}
