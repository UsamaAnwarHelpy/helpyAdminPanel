using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelpyAdmin.Models
{
    public class NotificationMessages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Notification Notification { get; set; }
        public int OriginalPriority { get; set; }
        public int Priority { get; set; }
        public long SentTime { get; set; } // Using long for timestamp
        public string Data { get; set; }   // Assuming Data can be of any type, you might want to define a specific type
        public string From { get; set; }
        public string MessageId { get; set; }
        public int Ttl { get; set; }
        public string CollapseKey { get; set; }
        public int UserId { get; set; }
    }

}
