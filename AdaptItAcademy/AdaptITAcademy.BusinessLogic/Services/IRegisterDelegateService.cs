using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Business_Rules
{
    public interface IRegisterDelegateService
    {
        void RegisterDelegate(RegisterDelegateDTO registerDelegateDTO);
        AdaptITAcademyContext GetContext(); // context to establish manual transaction commit & rollback.
    }
}
