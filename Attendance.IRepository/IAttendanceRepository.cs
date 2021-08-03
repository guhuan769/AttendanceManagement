using Attendance.IRepository.Base;
using Attendance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.IRepository
{
    interface IAttendanceRepository: IBaseAttendanceRepository<TravelAllowanceTable>
    {
    }
}
