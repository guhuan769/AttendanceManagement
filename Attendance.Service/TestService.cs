using Attendance.IRepository;
using Attendance.IService;
using Attendance.Repository;
using System;

namespace Attendance.Service
{
    public class TestService : ITestService
    {
        ITestRepository test = new TestRepository();
        public int Sum(int i, int j)
        {
            return test.Sum(i, j);
        }
    }
}
