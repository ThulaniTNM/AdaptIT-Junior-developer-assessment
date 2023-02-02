using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class PostalAddress {
        public int PostalAddressId { get; set; }
        public string Area { get; set; }
        public string Country { get; set; }
        public string PostalCodePostalAddress { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
