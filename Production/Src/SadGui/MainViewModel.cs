using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SadCL.MissileLauncher;

namespace SadCLGUI
{
    class MissileControlViewModel : ViewModelBase
    {

        private IMissileLauncher m_launcher = null;

        public MissileControlViewModel(IMissileLauncher launcher)
        {
            m_launcher = launcher;
            FireCommand = new DelegateCommand(Fire);
        }

        public void Fire()
        {
            m_launcher.fire();
        }
        public MissileControlViewModel MissileLauncher {
            get {
                return auncher;
            }
            private set {
                m_selectedLauncher = value;
                OnPropertyChanged("MissileLauncher");
            }
        }

        public ICommand FireCommand { get; set; }
    }
}
