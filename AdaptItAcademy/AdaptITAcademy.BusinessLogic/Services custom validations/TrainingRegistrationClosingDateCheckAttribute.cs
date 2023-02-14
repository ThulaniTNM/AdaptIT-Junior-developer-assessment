using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Custom_validations
{
    public class TrainingRegistrationClosingDateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var trainingDTO = (TrainingReadDTO)validationContext.ObjectInstance;
            var ClosingDate = (DateTime)value;

            if (ClosingDate > trainingDTO.TrainingRegistrationClosingDate)
            {
                return new ValidationResult("Closing date has to be smaller than start date");
            }

            return ValidationResult.Success;
        }
    }
}
