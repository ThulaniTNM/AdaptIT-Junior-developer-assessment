using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class PhysicalAddress {
        [Required(ErrorMessage = "Address Id required")]
        public int PhysicalAddressId { get; set; }

        [Required(ErrorMessage = "Address name required")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Suburb required")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Province required")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Postal code required")]
        [Range(4,4, ErrorMessage ="Postal code should be 4 numbers")]
        public int PostalCode { get; set; }


        [Required(ErrorMessage = "User id required")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
