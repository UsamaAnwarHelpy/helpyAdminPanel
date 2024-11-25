using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HelpyAdmin.Models
{
    public class FilterUserModel
    {
        public int? userId { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        [AllowNull]
        public string BodyType { get; set; }
        [AllowNull]
        public string Children { get; set; }
        [AllowNull]
        public string Drinking { get; set; }
        [AllowNull]
        public string Education { get; set; }
        [AllowNull]
        public string Ethnicity { get; set; }
        [AllowNull]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        public int? MinHeightInInches { get; set; }
        public int? MaxHeightInInches { get; set; }
        [AllowNull]
        public string Language { get; set; }
        [AllowNull]
        public string Occupation { get; set; }
        [AllowNull]
        public string RelationshipStatus { get; set; }
        public List<int>? SelectedItems { get; set; }
        [Required]
        public string Sexuality { get; set; }
        [AllowNull]
        public string Smoking { get; set; }
        [AllowNull]
        public string City { get; set; }
        [AllowNull]
        public string Country { get; set; }
        [AllowNull]
        public string Longitude { get; set; }
        [AllowNull]
        public string Latitude { get; set; }
        [AllowNull]
        public string LookingFor { get; set; }
        public int? Radius { get; set; }
    }
}
