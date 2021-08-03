using Attendance.IRepository;
using System;

namespace Attendance.Repository
{
    public class TestRepository : ITestRepository
    {
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
