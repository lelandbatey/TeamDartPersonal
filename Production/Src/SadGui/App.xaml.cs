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

            string FilePath = "C:\\Users\\jason_000\\Dropbox\\cs323\\jason_323.team.dart.git\\Production\\Src\\SadCL\\SadCL_Main\\SadCL_UnitTests\\TestData\\validTargets.ini";

            List<Target.Target> RawList = Target.TargetFactory.BuildTargetList(FilePath);


            MainWindowViewModel viewModel = new MainWindowViewModel(RawList);

            window.DataContext = viewModel;
            window.ShowDialog();
        }
    }
}
