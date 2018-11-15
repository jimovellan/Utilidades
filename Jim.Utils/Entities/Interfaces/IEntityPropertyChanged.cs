using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Jim.Utils.Entities.Interfaces
{
    class IEntityPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
