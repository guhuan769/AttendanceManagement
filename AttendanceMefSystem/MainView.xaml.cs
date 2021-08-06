using Attendance.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
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

namespace AttendanceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainView : Window
    {

        /// <summary>
        /// 如果使用 [ImportMany(typeof(IView))] 的方式，
        /// 可以省略 Plugins = container.GetExports<IView,IMetadata>();
        /// </summary>
        [ImportMany(typeof(IView))]
        public Lazy<IView, IMetadata>[] Plugins { get; private set; }

        private CompositionContainer container = null;
        public MainView()
        {
            InitializeComponent();

            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            if (dir.Exists)
            {
                var catalog = new DirectoryCatalog(dir.FullName, "Attendance.*.dll");
                container = new CompositionContainer(catalog);
                try
                {
                    container.ComposeParts(this);
                }
                catch (CompositionException compositionEx)
                {
                    Console.WriteLine(compositionEx.ToString());
                }

                Plugins.OrderBy(p => p.Metadata.Priority);

                foreach (var item in Plugins)
                {
                    this.tab.Items.Add(new TabItem()
                    {
                        Header = item.Metadata.Name,
                        Content = item.Value
                    });
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            container?.Dispose();
            base.OnClosing(e);
        }
    }
}
