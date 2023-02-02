using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class Training {
        public int TrainingID { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public int TrainingPeriod { get; set; }
        public DateTime TrainingEndDate { get; set; }
        public DateTime TrainingRegistrationClosingDate { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TrainingCost { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<UserTraining> UserTrainings { get; set; }
    }
}
