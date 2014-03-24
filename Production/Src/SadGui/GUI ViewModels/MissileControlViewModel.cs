using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SadCL.MissileLauncher;

namespace SadCLGUI
{
    class MissileControlViewModel
    {
        private IMissileLauncher m_launcher;

        private int distance = 50;

        public MissileControlViewModel(IMissileLauncher launcher)
        {
            m_launcher = launcher;
            FireCommand = new DelegateCommand(Fire);
            LeftCommand = new DelegateCommand(moveLeft);
            RightCommand = new DelegateCommand(moveRight);
            UpCommand = new DelegateCommand(moveUp);
            DownCommand = new DelegateCommand(moveDown);
        }

        public void Fire() {
            m_launcher.fire();
        }
        public void moveLeft() {
            m_launcher.moveBy(distance, 0);
        }
        public void moveRight() {
            m_launcher.moveBy(-distance, 0);
        }
        public void moveUp() {
            m_launcher.moveBy(0, distance);
        }
        public void moveDown() {
            m_launcher.moveBy(0, -distance);
        }

        public ICommand FireCommand { get; set; }
        public ICommand LeftCommand { get; set; }
        public ICommand RightCommand { get; set; }
        public ICommand UpCommand { get; set; }
        public ICommand DownCommand { get; set; }
    }
}
