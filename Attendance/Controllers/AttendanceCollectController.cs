using Attendance.core.Common.Redis;
using Attendance.Model;
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
    /// 考勤汇总
    /// </summary>
    public class AttendanceCollectController : BaseController
    {

        /// <summary>
        /// 出差补贴表仓库
        /// </summary>
        private ConcurrentDictionary<int, List<TravelAllowanceTable>> concurrentDic;

        /// <summary>
        /// Reids
        /// </summary>
        private readonly IRedisCacheManager _redisCacheManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public AttendanceCollectController(IRedisCacheManager redisCacheManager)
        {
            _redisCacheManager = redisCacheManager;
            if (concurrentDic == null)
            {
                concurrentDic = new ConcurrentDictionary<int, List<TravelAllowanceTable>>();
            }
        }

        #region 出差补贴

        /// <summary>
        /// 新增出差明细
        /// </summary>
        /// <param name="Status">Delete:删除，Update:更新,Post :新增 查询 默认值:Post</param>
        /// <param name="RedisName">Reids Key 默认:RedisTravelAllowance </param>
        /// <param name="travelAllowanceTables"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> TravelAllowanceAdd(string Status, string RedisName, List<TravelAllowanceTable> travelAllowanceTables)
        {
            try
            {
                var key = $"{RedisName}";
                if (key.Equals(string.Empty) || key == null) key = $"RedisTravelAllowance";
                if (Status.Equals(string.Empty)) key = $"Post";
                switch (Status)
                {
                    #region 新增
                    case "Post":
                        if (_redisCacheManager.GetList<object>(key) != null)
                        {
                            travelAllowanceTables = _redisCacheManager.GetList<TravelAllowanceTable>(key);

                            var aa = _redisCacheManager.GetValue(key);
                        }
                        else
                        {
                            _redisCacheManager.Set(key, travelAllowanceTables, TimeSpan.FromHours(2));//缓存2小时
                        }
                        break;
                    #endregion
                    case "Update":
                        _redisCacheManager.Remove(key);
                        if (_redisCacheManager.GetList<object>(key) != null)
                            _redisCacheManager.Set(key, travelAllowanceTables, TimeSpan.FromHours(2));//缓存2小时
                        break;
                    case "Delete":
                        _redisCacheManager.Remove(key);
                        break;
                    default:
                        break;
                }
                if (Status == "Post")
                    return Ok(travelAllowanceTables);
                else if (Status == "Update")

                    return Ok("");
                else
                    return Ok("参数不合理!");
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }

        #endregion

    }
}
