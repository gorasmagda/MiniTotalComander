using Projekt1MINITC.Model;
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
        public PanelModel PanelM = null;


        public PanelViewModel()
        {
            Drives = new ObservableCollection<string>();
            Folders = new ObservableCollection<string>();
            PanelM = new PanelModel();
        }


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
                        //zwraca kolekcję pełnych ścieżek do podfolderów w danej lokalizacji 
                        string[] folderlist = Directory.GetDirectories(Sciezka);
                        //zwraca kolekcję pełnych ścieżek do plików zawartych w danej lokalizacji
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
                        //zwraca ścieżkę do elementu, który wskzazuje ()
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



        //DriveComboBoxEvent
        private ICommand comboBoxClick;

        public ICommand ComboBoxClick => comboBoxClick ?? (comboBoxClick = new RelayCommand
            (o =>
            {
                Drives.Clear();
                //zwraca kolejkcję dysków ligicznych
                List<string> drives = PanelM.readDrives();
                foreach (string x in drives)
                    Drives.Add(x);


            }
            , null));





        //ListBoxDoubleClickEvent
        private ICommand listBoxDClick;
        public ICommand ListBoxDClick => listBoxDClick ?? (listBoxDClick = new RelayCommand(
            o => {
                if (SelectedFolder == "..")
                {
                    Sciezka = Path.GetDirectoryName(Path.GetDirectoryName(Sciezka));
                    if (!Sciezka.EndsWith("\\"))
                    {
                        Sciezka += "\\";
                    }
                }
                else 
                {
                    Sciezka += SelectedFolder.Remove(0, 3) + "\\";
                }
                SelectedFolder = null;
            }
            , null));


    }
}
