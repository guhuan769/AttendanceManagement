using System;
using System.ComponentModel;
using System.Composition;
using MefSample.IService;

namespace MefSample.Service
{
    [Description("具体服务")]
    [Export(nameof(DataService), typeof(IServices))]
    public class DataService : IServices
    {
        public void QueryData(int numuber, Action<int> action)
        {
            action(numuber * 100);
        }
    }
}
