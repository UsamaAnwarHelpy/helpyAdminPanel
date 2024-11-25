using HelpyAdmin.Models;
using static System.Net.Mime.MediaTypeNames;

namespace HelpyAdmin.ViewModel
{
    public class GetUserDetailsCiewModal
    {
        public Users Users { get; set; }
        public UserDetails UserDetails { get; set; }
        public Images Image { get; set; }
        public Subscriptions Subscription { get; set; }
    }
}
