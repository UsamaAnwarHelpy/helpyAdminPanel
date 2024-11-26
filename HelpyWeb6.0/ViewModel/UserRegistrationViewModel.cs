using System.ComponentModel.DataAnnotations;

namespace HelpyAdmin.ViewModel
{
    public class UserRegistrationViewModel
    {
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
        public string? Intentions { get; set; }
        //[Required]
        public string Email { get; set; }
        public string? Password { get; set; }
        //[Required]
        public string Ethnicity { get; set; }
        //[Required]
        public string FullName { get; set; }
        //[Required]
        public string Gender { get; set; }
        public string Occupation { get; set; }
        //[Required]
        public List<int> SelectedItems { get; set; }

        [Display(Name = "Upload Public Images")]
        [MinLength(1, ErrorMessage = "Please upload at least 1 image.")]
        [MaxLength(4, ErrorMessage = "You can upload a maximum of 4 images.")]
        public List<IFormFile> PublicImages { get; set; }

        [Display(Name = "Upload Private Images")]
        [MinLength(1, ErrorMessage = "Please upload at least 1 image.")]
        [MaxLength(4, ErrorMessage = "You can upload a maximum of 4 images.")]
        public List<IFormFile> PrivateImages { get; set; }
        public string Sexuality { get; set; }
        //[Required]
        public string City { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string LookingFor { get; set; }
        public string BodyType { get; set; }
        public string Children { get; set; }
        public string Drinking { get; set; }
        public string Education { get; set; }
        public int HeightInInches { get; set; }
        public string Language { get; set; }
        public string? RelationshipStatus { get; set; }
        public string? Smoking { get; set; }
    }
}
