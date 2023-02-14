using AdaptITAcademy.BusinessLogic.Custom_validations;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Data_transfer_objects
{
    public class TrainingReadDTO : TrainingDTO
    {
        [Required(ErrorMessage = "Training id required")]
        public int TrainingID { get; set; } // for posting not required but updates & delete require id.
    }
}
