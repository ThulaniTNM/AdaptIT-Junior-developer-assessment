using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class Course {
        [Column("Course code")]
        [Key]
        [Required(ErrorMessage = "Course id required")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course description required")]
        public string CourseDescription { get; set; }

        public ICollection<Training> Trainings { get; set; }
    }
}
