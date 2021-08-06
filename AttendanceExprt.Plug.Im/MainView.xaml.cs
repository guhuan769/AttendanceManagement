using AttendanceExport.Interface;
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

namespace AttendanceExprt.Plug.Im
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IView))]
    [CustomExportMetadata(0, "Plug.Im")]
    public partial class MainView : UserControl, IView
    {
        [ImportingConstructor]
        public MainView([Import("DataService")] IService service)
        {
            this.DataContext = new MianViewModel(service);
            InitializeComponent();
        }
    }
}
