using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1MINITC.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(params string[] propertiesNames)
            {
                if (PropertyChanged != null)
                {
                    foreach (var prop in propertiesNames)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
                    }
                }
            }

        }
    }


