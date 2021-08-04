using Attendance.Interface;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Plug1
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IService service;

        private int _number;
        public int Number
        {
            get { return _number; }
            set { Set(ref _number, value); }
        }

        private RelayCommand _todoCommand;

        public MainViewModel(IService service)
        {
            this.service = service;
        }

        public RelayCommand TodoCommand
        {
            get
            {
                return _todoCommand ?? (_todoCommand = new RelayCommand(() =>
                {
                    service?.QueryData(Number, sum => { this.Number = sum; });
                    MessengerInstance.Send(this.Number, "Plugin");
                }));
            }
        }

    }
}
