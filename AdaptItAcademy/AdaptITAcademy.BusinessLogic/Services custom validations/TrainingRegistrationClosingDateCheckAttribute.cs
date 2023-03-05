using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training;
using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademy.BusinessLogic.Custom_validations
{
    public class TrainingRegistrationClosingDateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var trainingDTO = (TrainingWriteDTO)validationContext.ObjectInstance;
            var ClosingDate = (DateTime)value;

            if (ClosingDate > trainingDTO.TrainingRegistrationClosingDate)
            {
                return new ValidationResult("Closing date has to be smaller than start date");
            }

            return ValidationResult.Success;
        }
    }
}
