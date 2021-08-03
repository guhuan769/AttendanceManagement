using AttendanceRESTful.Interface.Realization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceRESTful.Controllers
{
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
            RedisCacheManager redisCacheManager = new RedisCacheManager();
            //ITestService testService = new TestService();
            return i+j+5; /*testService.Sum(i, j);*/
        }
    }
}
