using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m2m.MVVMLigth.Logic.UI
{
    public class Screen2ViewModel : ViewModelBase
    {
        public Screen2ViewModel()
        {
            SomeText = "text from ViewModel";
        }

        public string SomeText { get; set; }
    }
}