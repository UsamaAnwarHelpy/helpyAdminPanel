using System.ComponentModel.DataAnnotations;

namespace HelpyAdmin.ViewModel
{
    public class UserImageUploadModel
    {
        [Required]
        public string Key { get; set; } // e.g., "Profile_image", "Gallery_image"

        [Required]
        public string Url { get; set; } // URL of the image

        public int IsPrivate { get; set; }
    }
}
