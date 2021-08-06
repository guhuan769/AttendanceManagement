using GalaSoft.MvvmLight;

namespace Attendance.ExportOrImport
{
    public class MainViewModel : ViewModelBase
    {
        private int _number;
        public int Number
        {
            get { return _number; }
            set { Set(ref _number, value); }
        }
        public MainViewModel()
        {
            MessengerInstance.Register<int>(this, "Plugin", obj => 
            {
                this.Number = -obj;
            });
        }
    }
}
