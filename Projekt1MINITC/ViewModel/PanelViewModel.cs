using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt1MINITC.ViewModel
{
    class PanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Drives { get; set; }
        public ObservableCollection<string> Folders { get; set; }

        public PanelViewModel()
        {
            Drives = new ObservableCollection<string>();
            Folders = new ObservableCollection<string>();
        }

        private ICommand comboBoxClick;

        public ICommand ComboBoxClick => comboBoxClick ?? (comboBoxClick = new RelayCommand
            (o =>
            {
                Drives.Clear();
                string[] drives = Directory.GetLogicalDrives();

                foreach (var x in drives)
                    Drives.Add(x);
                
            }
            , null));



    }
}
