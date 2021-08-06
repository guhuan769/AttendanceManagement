using AttendanceExport.Interface;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AttendanceExport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <summary>
    /// 如果使用 [ImportMany(typeof(IView))] 的方式，
    /// 可以省略 Plugins = container.GetExports<IView,IMetadata>();
    /// </summary>
   
    public partial class MainWindow : Window
    {
        [ImportMany(typeof(IView))]
        public Lazy<IView, IMetadata>[] Plugins { get; private set; }

        private readonly CompositionContainer container = null;
        public MainWindow()
        {
            InitializeComponent();

            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            if (dir.Exists)
            {
                var catalog = new DirectoryCatalog(dir.FullName, "AttendanceExprt.*.dll");
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
                    //this.tab.Items.Add(new TabItem()
                    //{
                    //    Header = item.Metadata.Name,
                    //    Content = item.Value
                    //});
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
