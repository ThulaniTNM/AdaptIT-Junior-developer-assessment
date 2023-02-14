using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Data_transfer_objects.Course
{
    public class CourseDTO
    {

        [Required(ErrorMessage = "Course name required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course description required")]
        public string CourseDescription { get; set; }
    }
}
