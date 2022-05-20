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
    class PanelViewModel : BaseViewModel
    {
        
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

        private string selectedDrive;
        public string SelectedDrive
        {
            get => selectedDrive;
            set
            {
                selectedDrive = value;
                Sciezka = SelectedDrive;
                OnPropertyChanged(nameof(SelectedDrive));
               
            }
        }

        private string sciezka;

        public string Sciezka
        {
            get => sciezka;
            set
            {
                sciezka = value;
                Folders.Clear();
                if(Sciezka != null)
                {
                    try
                    {
                        string[] folderlist = Directory.GetDirectories(Sciezka);
                        string[] filelist = Directory.GetFiles(Sciezka);
                        if(Sciezka.Length > 3)
                        {
                            Folders.Add("..");
                        }
                        foreach(string f in folderlist)
                        {
                            Folders.Add("<D>" + Path.GetFileName(f));
                        }
                        foreach(string file in filelist)
                        {
                            Folders.Add(Path.GetFileName(file));
                        }

                    }
                    catch
                    {
                        Console.WriteLine("ERROR!");
                        Sciezka = Path.GetDirectoryName(Path.GetDirectoryName(Sciezka));
                    }
                    OnPropertyChanged(nameof(Sciezka));
                }

            }
        }

        private string selectedFolder;

        public string SelectedFolder
        {
            get => selectedFolder;
            set
            {
                selectedFolder = value;
                OnPropertyChanged(nameof(selectedFolder));
            }
        }

        //ListBoxDoubleClick
        private ICommand listBoxDClick;
        public ICommand ListBoxDClick => listBoxDClick ?? (listBoxDClick = new RelayCommand(
            o => {
                if (SelectedFolder.Equals(".."))
                {
                    Sciezka = Path.GetDirectoryName(Path.GetDirectoryName(Sciezka));
                    if (!Sciezka.EndsWith("\\"))
                    {
                        Sciezka += "\\";
                    }
                }
                else if (SelectedFolder.StartsWith("<D>"))
                {
                    Sciezka += SelectedFolder.Remove(0, 3) + "\\";
                }
                SelectedFolder = null;
            }
            , null));


    }
}
