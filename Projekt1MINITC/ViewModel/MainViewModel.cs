using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Windows;
using Projekt1MINITC.Model;

namespace Projekt1MINITC.ViewModel
{
    

    class MainViewModel : BaseViewModel
    {
        
        public PanelViewModel LeftPanel { get; set; }
        public PanelViewModel RightPanel { get; set; }

        public MainViewModel()
        {
            LeftPanel = new PanelViewModel();
            RightPanel = new PanelViewModel();
        }

        private ICommand copyClick;
        public ICommand CopyClick => copyClick ?? (copyClick = new RelayCommand(
            o =>
            {
               
                    string pSource = LeftPanel.Sciezka + LeftPanel.SelectedFolder;
                    string pTarget = RightPanel.Sciezka + LeftPanel.SelectedFolder;
                    try
                    {
                        MainModel.CopyFile(pSource, pTarget);
                    }
                    catch
                    {
                        MessageBox.Show("ERROR!");
                    }
                    RightPanel.Sciezka = RightPanel.Sciezka;
                
                
            },
            o => LeftPanel.Sciezka != null && RightPanel.Sciezka != null));
    }

    
}
