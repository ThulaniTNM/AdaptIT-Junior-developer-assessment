using AdaptITAcademy.DataAccess.Models;
using AdaptITAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Data_transfer_objects
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "Course id required")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course description required")]
        public string CourseDescription { get; set; }
    }
}
