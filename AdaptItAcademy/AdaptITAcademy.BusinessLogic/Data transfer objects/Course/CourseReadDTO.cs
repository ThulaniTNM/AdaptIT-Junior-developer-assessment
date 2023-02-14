using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Course;
using AdaptITAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Data_transfer_objects
{
    public class CourseReadDTO : CourseDTO
    {
        [Required(ErrorMessage = "Course id required")]
        public int CourseId { get; set; }
    }
}
