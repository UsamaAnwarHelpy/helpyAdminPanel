namespace HelpyAdmin.Models
{
    public class Viewed
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ViewedUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
