using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdaptITAcademyAPI.Models {
    public class Course {
        [Column("Course code")]
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }

        public ICollection<Training> Trainings { get; set; }
    }
}
