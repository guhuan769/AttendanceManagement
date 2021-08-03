using Attendance.IService;
using Attendance.Model;
using Attendance.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service
{
    public class AttendanceService : BaseAttendanceService<TravelAllowanceTable>, IAttendanceService
    {

    }
}
