using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace CaseMark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime curentTime;
        DispatcherTimer T;
        private static bool togle = true;
        public MainWindow()
        {
            InitializeComponent();
            MinMaxWindow();
            dateT.Text = DateTime.Now.ToString("g", CultureInfo.CreateSpecificCulture("ka-GE"));
            T = new DispatcherTimer();
            T.Interval = TimeSpan.FromSeconds(1);
            T.Tick += tikcet;
            T.Start();
            DisplayDate();
        }

        private void tikcet(object sender, EventArgs e)
        {
            
            curentTime = DateTime.Now;
            dateT.Text = curentTime.ToString("g", CultureInfo.CreateSpecificCulture("ka-GE"));
            if (curentTime.Date.Second % 10 == 0)
                DisplayDate();
            
        }
        private void MinMaxWindow()
        {
            if (togle)
            {
                MWindow.WindowState = WindowState.Maximized;
                MWindow.WindowStyle = WindowStyle.None;
            }
            else
            {
                MWindow.WindowState = WindowState.Normal;
                MWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            }

        }
        private void DisplayDate()
        {
            DisplaCases.ItemsSource = DBControl.GetAllCases();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                togle = !togle;
            }
            MinMaxWindow();
        }

        private void MWindow_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            
                togle = !togle;
            MinMaxWindow();
        }
    }
}
