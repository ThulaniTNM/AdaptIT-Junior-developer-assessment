using AdaptITAcademy.BusinessLogic.Custom_validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Data_transfer_objects.Physical_address
{
    public class PhysicalAddressWriteDTO
    {
        [Required(ErrorMessage = "Address name required")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Suburb required")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Province required")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Postal code required")]
        [PostalCodeCheckAttribute]
        public int PostalCodePhysicalAddress { get; set; }
    }
}
