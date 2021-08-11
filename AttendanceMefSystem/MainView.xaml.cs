using Attendance.Interface;
using AttendanceClient.ViewModel;
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

        private MainViewModel _mainViewModel;

        public MainView()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            if (_mainViewModel == null)
            {
                _mainViewModel = new MainViewModel();
            }

            foreach (var item in _mainViewModel.Plugins)
            {
                this.tab.Items.Add(new TabItem()
                {
                    Header = item.Metadata.Name,
                    Content = item.Value
                });
            }

        }
    

    protected override void OnClosing(CancelEventArgs e)
    {
        _mainViewModel.container?.Dispose();
        base.OnClosing(e);
    }

    private void TabMoveLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            this.DragMove();
        }
    }
}
}
