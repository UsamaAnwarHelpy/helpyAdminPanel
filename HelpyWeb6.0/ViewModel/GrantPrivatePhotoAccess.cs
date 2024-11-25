namespace HelpyAdmin.ViewModel
{
    public class GrantPrivatePhotoAccess
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int TargetUserId { get; set; }
        public bool isGranted { get; set; }
        public string FsmToken { get; set; }
    }
}
