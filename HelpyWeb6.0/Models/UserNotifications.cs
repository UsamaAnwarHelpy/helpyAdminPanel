using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelpyAdmin.Models
{
    public class UserNotifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FsmToken { get; set; }
        public string? MessageText { get; set; }
        public DateTime SendTime { get; set; }
        public string SenderName { get; set; }
        public int TargetUserId { get; set; }
    }
}
