namespace HelpyAdmin.ViewModel
{
    public class UserChatDetail
    {
        public int Id { get; set; }
        public int SenderID { get; set; }
        public string SenderUsername { get; set; }
        public string SenderImage { get; set; }
        public int RecieverID { get; set; }
        public string LastMessage { get; set; }
        public string ReceiverUsername { get; set; }
        public string ReceiverImage { get; set; }
    }
}
