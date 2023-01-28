using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class PostalAddress {
        [Required(ErrorMessage = "Postal address id required")]
        public int PostalAddressId { get; set; }

        [Required(ErrorMessage = "Area required")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Country required")]
        public string Country { get; set; }
        
        [Required(ErrorMessage = "Postal code required")]
        [Range(4, 4, ErrorMessage = "Postal code should be 4 numbers")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "User id required")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
