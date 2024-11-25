using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelpyAdmin.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TargetUserId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageLink { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
