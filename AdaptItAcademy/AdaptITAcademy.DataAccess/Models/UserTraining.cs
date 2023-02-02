using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class UserTraining {
        public int UserTrainingId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public string PaymentStatus { get; set; }
    }
}
