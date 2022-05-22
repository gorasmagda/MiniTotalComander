using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1MINITC.Model
{
    class MainModel
    {
        public static void CopyFile(string source, string target)
        {
            File.Copy(source, target);
        }
    }
}
