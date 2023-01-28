using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class User {
        [Required(ErrorMessage = "User id required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        [Range(10, 10, ErrorMessage = "10 numbers required")]
        public int PhonenNumer { get; set; }

        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Dietary option required")]
        public DietaryRequirements DietaryRequirements { get; set; }

        [Required(ErrorMessage = "Company name required")]
        public string CompanyName { get; set; }

        public ICollection<PhysicalAddress> PhysicalAddresses { get; set; }
        public ICollection<PostalAddress> PostalAddresses { get; set; }
        public ICollection<UserTraining> UserTrainings { get; set; }
    }

    public enum DietaryRequirements {
        Vegetarian,
        Halal,
        Vegan,
        Other
    }
}
