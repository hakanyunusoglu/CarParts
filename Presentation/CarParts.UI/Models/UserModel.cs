namespace CarParts.UI.Models
{
    public class UserModel
    {
        
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string Phones { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
