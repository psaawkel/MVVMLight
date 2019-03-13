using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m2m.MVVMLigth.Logic.UI
{
    public class Screen1ViewModel : ViewModelBase
    {
        public Screen1ViewModel(){
            SomeText = "Wow! Many ViewModels! Very computer! Wow!";
        }

        public string SomeText { get; set; }
    }
}
