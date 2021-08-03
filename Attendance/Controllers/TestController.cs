using Attendance.IService;
using Attendance.Model;
using Attendance.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendance.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    /// <summary>
    /// 测试求和
    /// </summary>
    public class TestController : BaseController
    {
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        [HttpGet]
        public int Sum(int i, int j)
        {
            ITestService testService = new TestService();
            return testService.Sum(i, j);
        }
    }


}
