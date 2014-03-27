using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SadCLGUI.GUI_ViewModels
{
    class TargetBriefListViewModel
    {
        public TargetViewModel TargetsViewModel { get; set; }
        public ObservableCollection<TargetViewModel> Targets {get; private set; }
        public TargetBriefListViewModel(List<Target.Target> RawList) {
            
            Targets = new ObservableCollection<TargetViewModel>();
            foreach (Target.Target target in RawList) {
                Targets.Add(new TargetViewModel(target));    
            }
        }
    }
}
