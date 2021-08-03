using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendance.Controllers
{
    /// <summary>
    /// 自定义模板
    /// 用于解决swagger文档没有操作范文的定义
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase //where T :class
    {
        //public ConcurrentDictionary<string, List<T>> concurrentDic;  
    }
}
