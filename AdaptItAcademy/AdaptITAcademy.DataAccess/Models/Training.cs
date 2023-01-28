using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class Training {

        [Required(ErrorMessage ="Training id required")]
        public int TrainingID { get; set; }

        [Required(ErrorMessage ="Training day start day required")]
        public DateTime TrainingStartDate { get; set; }

        [Required(ErrorMessage ="Number of training days required")]
        [Range(1,5,ErrorMessage ="Number of training minimal a day, maximum a week")]
        public int TrainingPeriod { get; set; } // assumptions that training may not last more than a 5 days.
        public DateTime TrainingEndDate { get; set; }

        [Required(ErrorMessage = "Training reigstration closing date required")]
        public DateTime TrainingRegistrationClosingDate { get; set; }

        [Required(ErrorMessage = "Number of available seats required")]
        [Range(0,int.MaxValue,ErrorMessage ="Seats cannot be less than 0")]
        public int AvailableSeats { get; set; }

        [Required(ErrorMessage ="Training cost is required")]
        [Range(0.0, double.MaxValue , ErrorMessage = "Training cost cannot be less than 0")]
        public double TrainingCost { get; set; }

        [Required(ErrorMessage = "Course id required")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<UserTraining> UserTrainings { get; set; }
    }
}
