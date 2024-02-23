using System.ComponentModel.DataAnnotations;

namespace AssetManagmentSystem2.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
