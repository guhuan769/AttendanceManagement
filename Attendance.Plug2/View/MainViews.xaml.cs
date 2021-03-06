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

namespace Attendance.ExportOrImport
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IView))]
    [CustomExportMetadata(0, "Export")]
    public partial class MainViews : UserControl, IView
    {
        [ImportMany(typeof(IWeight))]
        public Lazy<IWeight, IMetadata>[] Weights { get; private set; }
        public MainViews()
        {
            this.DataContext = new MainViewModel();
            InitializeComponent();
        }

        private void Loading_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //this.lv.Items.Clear();
            //foreach (var weight in Weights)
            //{
            //    var expander = new Expander()
            //    {
            //        Header = weight.Metadata.Description
            //    };
            //    expander.Content = weight.Value;
            //    this.lv.Items.Add(expander);
            //}
        }

        private void Button_MouseDown(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Login");
        }
    }
}
