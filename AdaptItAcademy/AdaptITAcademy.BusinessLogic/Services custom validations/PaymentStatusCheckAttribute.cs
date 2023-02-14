using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Custom_validations
{
    public class PaymentStatusCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string paymentStatus = value.ToString().ToLower();

            if (paymentStatus == "free" || paymentStatus == "paid")
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Payment status for delegate training can have one of two values : free / paid");
        }
    }
}
