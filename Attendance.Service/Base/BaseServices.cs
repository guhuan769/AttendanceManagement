using Attendance.IRepository.Base;
using Attendance.IService.Base;
using Attendance.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.Base
{
    public class BaseServices<Tentity> : IBaseServices<Tentity> where Tentity : class, new()
    {
        public IBaseRepository<Tentity> baseDal = new BaseRepository<Tentity>();

        public BaseServices(IBaseRepository<Tentity> baseRepository)
        {
            baseDal = baseRepository;
        }

        public Task<bool> Add(Tentity model)
        {
            return baseDal.Add(model);
        }

        public Task<bool> DeleteByIds(object[] ids)
        {
            return baseDal.DeleteByIds(ids);
        }

        public Task<Tentity> QueryByID(object objId)
        {
            return baseDal.QueryByID(objId);
        }

        public Task<bool> Update(Tentity model)
        {
            return baseDal.Update(model);
        }
    }
}
