using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class UserTraining {
        [Required(ErrorMessage = "User-Training id required")]
        public int UserTrainingId { get; set; }

        [Required(ErrorMessage = "User id required")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Training id required")]
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        [Required(ErrorMessage = "Payment status required")]
        public string PaymentStatus { get; set; }
    }
}
