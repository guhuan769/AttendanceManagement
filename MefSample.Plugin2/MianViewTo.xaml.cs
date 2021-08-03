using MefSample.Core;
using MefSample.IService;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MefSample.Plugin2
{
    /// <summary>
    /// MianViewTo.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IView))]
    [CustomExportMetadata(1, "Plugin 2", "这是第一个插件", "hippiezhou", "1.0")]
    public partial class MianViewTo : UserControl, IView
    {
        public readonly IServices Service;
        [ImportingConstructor]
        public MianViewTo([Import("DataService")] IServices service)
        {
            InitializeComponent();

            Service = service;
            Service.QueryData(10, sum => { this.tb.Text = sum.ToString(); });
        }
    }
}
