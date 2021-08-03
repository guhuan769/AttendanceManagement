using Attendance.core.Common.Helper;
using Attendance.core.Common.Redis;
using Attendance.IRepository;
using Attendance.IService;
using Attendance.Model;
using Attendance.Service;
using Microsoft.AspNetCore.Authorization;
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
    /// 测试管理
    /// </summary>
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IRedisCacheManager _redisCacheManager;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService,IUserRepository userRepository, IRedisCacheManager redisCacheManager)
        {
            _userService = userService;
            _redisCacheManager = redisCacheManager;
            _userRepository = userRepository;
        }

        #region Redis

        [HttpPost]
        public async Task<IActionResult> redisAdd(List<User> user)
        {
            var key = $"Redis0";
            if (_redisCacheManager.GetList<object>(key) != null)
            {
                user = _redisCacheManager.GetList<User>(key);
            }
            else
            {
                _redisCacheManager.Set(key, user, TimeSpan.FromHours(2));//缓存2小时
            }

            return Ok(user);
        }

        /// <summary>
        /// 测试Redis
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Redis(int id)
        {

            var key = $"Redis{id}";
            User user = new User();
            if (_redisCacheManager.Get<object>(key) != null)
            {
                user = _redisCacheManager.Get<User>(key);
            }
            else
            {
                user = await _userRepository.QueryByID(id);//GetById(id);使用集合操作
                _redisCacheManager.Set(key, user, TimeSpan.FromHours(2));//缓存2小时
            }

            return Ok(user);
        }
        #endregion

#if true
        #region 测试
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("fdsfs");
        }

        [HttpGet]
        public IActionResult Login(string role)
        {
            string jwtStr = string.Empty;
            bool suc = false;

            if (role != null)
            {
                // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
                TokenModel tokenModel = new TokenModel { Uid = "abcde", Role = role };
                jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }

        /// <summary>
        /// 获取User实体
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public IActionResult User(User user)
        {
            return Ok(user);
        }

        /// <summary>
        /// 需要Admin权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return Ok("hello admin");
        }

        /// <summary>
        /// 需要System和Admin权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "SystemOrAdmin")]

        public IActionResult SystemAndAdmin()
        {
            return Ok("hello SystemOrAdmin");
        }

        /// <summary>
        /// 解析Token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult ParseToken()
        {
            //需要截取Bearer 
            var tokenHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var user = JwtHelper.SerializeJwt(tokenHeader);
            return Ok(user);

        }

        /// <summary>
        /// 需要System权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "System")]
        public IActionResult System()
        {
            return Ok("hello System");
        }
        #endregion  
#endif

        #region User
        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id">参数id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetUser(int id)
        {
            User user = await _userService.QueryByID(id);
            return Ok(user);
        }


        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="id">参数id</param>
        /// <returns></returns>
        [HttpPost("{id}", Name = "post")]
        public async Task<IActionResult> Add(User user)
        {
            var count = await _userService.Add(user);
            return Ok(count);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">参数id</param>
        /// <returns></returns>
        [HttpPut("{id}", Name = "put")]
        public async Task<IActionResult> Update(User user)
        {
            var sucess = await _userService.Update(user);
            return Ok(sucess);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">参数id</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "Delete")]
        public async Task<IActionResult> Delete(object[] ids)
        {
            var sucess = await _userService.DeleteByIds(ids);
            return Ok(sucess);
        }

        [HttpPost]
        public async Task<IActionResult> Autofac()
        {
            var count = await _userService.GetCount();
            return Ok(count);
        }
        #endregion
    }
}
