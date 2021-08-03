using Attendance.IRepository;
using Attendance.IRepository.Base;
using Attendance.IService;
using Attendance.Model;
using Attendance.Repository;
using Attendance.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service
{
    public class UserService : BaseServices<User>, IUserService
    {
        private readonly IUserRepository user;

        public UserService(IBaseRepository<User> baseRepository, IUserRepository userRepository):base(baseRepository)
        {
            this.user = userRepository;
        }

        public Task<int> GetCount()
        {
            return user.GetCount();
        }
    }
}
