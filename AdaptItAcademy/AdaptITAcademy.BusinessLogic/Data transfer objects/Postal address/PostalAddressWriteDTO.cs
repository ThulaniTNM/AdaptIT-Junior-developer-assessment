using AdaptITAcademy.BusinessLogic.Custom_validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Data_transfer_objects.Postal_address
{
    public class PostalAddressWriteDTO
    {
        [Required(ErrorMessage = "Area required")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Country required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Postal code required")]
        [PostalCodeCheckAttribute]
        public int PostalCodePostalAddress { get; set; }
    }
}
