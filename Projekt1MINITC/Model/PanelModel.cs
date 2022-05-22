using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1MINITC.Model
{
    class PanelModel
    {
        public string Sciezka { get; set; }
        public List<string> readDrives()
        {
            List<string> ldrives = new List<string>();
            string[] drives = Directory.GetLogicalDrives();

            foreach (var x in drives)
                ldrives.Add(x);

            return ldrives;
        }

        public string readPath(string selectedFolder)
        {
            if (selectedFolder == "..")
            {
                Sciezka = Path.GetDirectoryName(Path.GetDirectoryName(Sciezka));
                if (!Sciezka.EndsWith("\\"))
                {
                    Sciezka += "\\";
                }
            }
            else
            {
                Sciezka += selectedFolder.Remove(0, 3) + "\\";
            }
            return Sciezka;
        }

        public List<string> readFiles()
        {
            List<string> folders = new List<string>();
            if (Sciezka != null)
            {
                
                //zwraca kolekcję pełnych ścieżek do podfolderów w danej lokalizacji 
                string[] folderlist = Directory.GetDirectories(Sciezka);
                //zwraca kolekcję pełnych ścieżek do plików zawartych w danej lokalizacji
                string[] filelist = Directory.GetFiles(Sciezka);
                if (Sciezka.Length > 3)
                {
                   folders.Add("..");
                }
                foreach (string f in folderlist)
                {
                  folders.Add("<D>" + Path.GetFileName(f));
                }
                foreach (string file in filelist)
                {
                   folders.Add(Path.GetFileName(file));
                }

                }
            return folders;
                
                    
               
            
        }
            
    }
}
