using System;
using System.ComponentModel;

namespace MefSample.IService
{
    [Description("服务接口")]
    public interface IServices
    {
        void QueryData(int numuber, Action<int> action);
    }
}
