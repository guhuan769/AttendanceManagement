using Attendance.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.Base
{
    public class BaseAttendanceService<TEntity> : IBaseAttendanceService<TEntity> where TEntity : class, new()
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public TEntity1 Get<TEntity1>(string key)
        {
            throw new NotImplementedException();
        }

        public bool Get(string key)
        {
            throw new NotImplementedException();
        }

        public List<TEntity1> GetList<TEntity1>(string key)
        {
            throw new NotImplementedException();
        }

        public string GetValue(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            throw new NotImplementedException();
        }
    }
}
