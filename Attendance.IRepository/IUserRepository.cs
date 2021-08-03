using Attendance.IRepository.Base;
using Attendance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.IRepository
{
    public interface IUserRepository: IBaseRepository<User>
    {
        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetCount();
    }
}
