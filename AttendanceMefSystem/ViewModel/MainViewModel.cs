using AttendanceClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttendanceClient.ViewModel
{
    public class MainViewModel
    {
        public CommandBase CloseWindowCommand { get; set; }

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
        }
    }
}
