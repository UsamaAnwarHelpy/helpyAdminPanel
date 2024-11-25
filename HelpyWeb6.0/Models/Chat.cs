using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpyAdmin.Models
{
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ChatID { get; set; }
        public int User1ID { get; set; }
        public int User2ID { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Users User1 { get; set; }
        public Users User2 { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
