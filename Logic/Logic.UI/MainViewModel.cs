using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using PropertyChanged;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace m2m.MVVMLigth.Logic.UI
{
    public class MainViewModel : ViewModelBase
    {

        private List<ViewModelBase> viewsList = new List<ViewModelBase>();

        private int Cnt { get; set; }

        public MainViewModel()
        {
            WindowTitle = "ApplicationMVVMLight";
            Cnt = 0;
            Progress = 0;
            Task.Run(
                () => Task.Delay(1000).ContinueWith(
                    t =>
                    {
                        while (true)
                        {
                            DispatcherHelper.RunAsync(() => {
                                this.Progress += 1;
                                if (Progress > 100)
                                {
                                    Progress = 0;
                                    Cnt++;
                                }
                            });
                            Task.Delay(10).Wait();
                        }
                    }
                )
            );


            ButtonCmd = new RelayCommand(() =>
            {
                Cnt++;
            }
            );


            viewsList.Add(new Screen1ViewModel());
            viewsList.Add(new Screen2ViewModel());

        }

        public ICommand ButtonCmd { get; private set; }

        [DependsOn(nameof(Cnt))]
        public ViewModelBase PrimaryModel {
            get {
                return viewsList[Cnt % viewsList.Count];
            }
            set {}
        }

        [DependsOn(nameof(Cnt))]
        public string BtnCont { get { return Cnt.ToString(); } }

        [DependsOn(nameof(Cnt))]
        public string WindowTitle { get { return "Clicked " + Cnt + " times"; } set { } }

        public int Progress { get; set; }
    }
}