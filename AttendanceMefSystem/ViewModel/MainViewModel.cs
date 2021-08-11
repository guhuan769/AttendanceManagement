using Attendance.Interface;
using AttendanceClient.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttendanceClient.ViewModel
{
    public class MainViewModel
    {
        public CommandBase CloseWindowCommand { get; set; }

        /// <summary>
        /// 如果使用 [ImportMany(typeof(IView))] 的方式，
        /// 可以省略 Plugins = container.GetExports<IView,IMetadata>();
        /// </summary>
        [ImportMany(typeof(IView))]
        public Lazy<IView, IMetadata>[] Plugins { get; private set; }

        public CompositionContainer container = null;
        public MainViewModel()
        {
            CloseWindowCommand = new CommandBase();

            #region 窗口关闭
            this.CloseWindowCommand.DoExecute = new Action<object>
                  (o =>
                  {
                      (o as Window).Close();
                  });

            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>
                (o =>
                {
                    return true;
                });
            #endregion
            Init();
        }

        private void Init()
        {

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
            }
        }
    }
}
