namespace HelpyAdmin.Models
{
    public class UserChat
    {
        public int Id { get; set; }
        public int SenderID { get; set; }
        public int RecieverID { get; set; }
        public string LastMessage { get; set; }

    }
}
