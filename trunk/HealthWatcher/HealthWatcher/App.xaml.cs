using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace HealthWatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            View.Login window = new HealthWatcher.View.Login();
            window.Left = (Screen.PrimaryScreen.Bounds.Width * 72 / 96) / 2 - 225;
            window.Top = (Screen.PrimaryScreen.Bounds.Height * 72 / 96) / 2 - 175;

            ViewModel.LoginViewModel vm = new HealthWatcher.ViewModel.LoginViewModel();
            window.DataContext = vm;

            window.Show();
        }
    }
}
