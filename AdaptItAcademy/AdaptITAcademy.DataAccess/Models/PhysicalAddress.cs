using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class PhysicalAddress {
        public int PhysicalAddressId { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string Province { get; set; }
        public string PostalCodePhysicalAddress { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
