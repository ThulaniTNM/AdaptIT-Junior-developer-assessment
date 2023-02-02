using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class User { // user in this case = delegate to be registered for training.
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhonenNumer { get; set; }

        public string Email { get; set; }

        public DietaryRequirements DietaryRequirements { get; set; }

        public string CompanyName { get; set; }

        public ICollection<PhysicalAddress> PhysicalAddresses { get; set; }
        public ICollection<PostalAddress> PostalAddresses { get; set; }
        public ICollection<UserTraining> UserTrainings { get; set; }
    }

    public enum DietaryRequirements {
        Vegetarian = 1,
        Halal = 2,
        Vegan = 3,
        Other = 4
    }
}
