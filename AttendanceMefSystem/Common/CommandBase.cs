using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttendanceClient.Common
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //DoCanExecute?.Invoke(parameter) 等于true就返回true
            return DoCanExecute?.Invoke(parameter) == true;
        }

        public void Execute(object parameter)
        {
            //DoExecute? 为空不调用 不为空则调用Invoke
            DoExecute?.Invoke(parameter);
        }

        public Action<object> DoExecute { get; set; }

        public Func<object,bool> DoCanExecute { get; set; }
    }
}
