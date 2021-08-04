using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Interface
{
    public interface IService
    {
        void QueryData(int numuber, Action<int> action);
    }
}
