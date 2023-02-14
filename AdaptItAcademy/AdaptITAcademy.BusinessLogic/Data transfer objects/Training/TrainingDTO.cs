using AdaptITAcademy.BusinessLogic.Custom_validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training
{
    public class TrainingDTO
    {
        [Required(ErrorMessage = "Training start date required")]
        public DateTime TrainingStartDate { get; set; }

        [Required(ErrorMessage = "Number of training days required")]
        [Range(1, 5, ErrorMessage = "Number of training minimal a day, maximum a week")]
        public int TrainingPeriod { get; set; } // assumptions that training may not last more than a 5 days.

        [Required(ErrorMessage = "Training reigstration closing date required")]
        [TrainingRegistrationClosingDateCheck]
        public DateTime TrainingRegistrationClosingDate { get; set; }

        [Required(ErrorMessage = "Number of available seats required")]
        [Range(0, 10, ErrorMessage = "Seats cannot be less than 0")] // max of 10 seats allowed for each training creation
        public int AvailableSeats { get; set; }

        [Required(ErrorMessage = "Training cost is required")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Training cost cannot be less than 0")]
        public decimal TrainingCost { get; set; }

        [Required(ErrorMessage = "Course id required")]
        public int CourseId { get; set; } // training for certain course
    }
}
