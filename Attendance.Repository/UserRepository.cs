using Attendance.IRepository;
using Attendance.Model;
using Attendance.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public async Task<int> GetCount()
        {
            var i = await Task.Run(()=> UserDb.Count(x => 1==1));
            return i;
        }
    }
}
