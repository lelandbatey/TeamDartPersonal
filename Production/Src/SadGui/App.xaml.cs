using SadCLGUI.GUI_ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SadCL.MissileLauncher;

namespace SadCLGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e) {
            MainWindow window = new MainWindow();

            IMissileLauncher launcher = MissileLauncherFactory.create_Launcher(LauncherTypes.DreamCheeky);

            MainWindowViewModel viewModel = new MainWindowViewModel(launcher);

            window.DataContext = viewModel;
            window.ShowDialog();
        }
    }
}
