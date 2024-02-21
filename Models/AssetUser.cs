namespace AssetManagmentSystem2.Models
{
    public class AssetUser
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Asset Asset { get; set; }
    }
}
