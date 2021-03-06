using Attendance.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace Attendance.Plug1
{
    /// <summary>
    /// MainVIew.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IView))]
    [CustomExportMetadata(0, "Plug1")]
    public partial class MainVIew : UserControl,IView
    {
        [ImportingConstructor]
        public MainVIew([Import("DataService")] IService service)
        {
            this.DataContext = new MainViewModel(service);
            InitializeComponent();
        }
    }
}
