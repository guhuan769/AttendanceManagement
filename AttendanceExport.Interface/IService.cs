using System;

namespace AttendanceExport.Interface
{
    public interface IService
    {
        void QueryData(int numuber, Action<int> action);
    }
}