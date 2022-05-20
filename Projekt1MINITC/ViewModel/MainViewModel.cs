using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1MINITC.ViewModel
{
    

    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PanelViewModel LeftPanel { get; set; }
        public PanelViewModel RightPanel { get; set; }

        public MainViewModel()
        {
            LeftPanel = new PanelViewModel();
            RightPanel = new PanelViewModel();
        }
    }

    
}
