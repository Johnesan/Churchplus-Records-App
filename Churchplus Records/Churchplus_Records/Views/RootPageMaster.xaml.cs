using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Churchplus_Records.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPageMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public RootPageMaster()
        {
            InitializeComponent();
            BindingContext = new RootPageMasterViewModel();
        }



        class RootPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<RootPageMenuItem> MenuItems { get; }
            public RootPageMasterViewModel()
            {
                //Sets the Items for the listView using the RootPageMenuItem.cs Model defined
                MenuItems = new ObservableCollection<RootPageMenuItem>(new[]
                 {
                    new RootPageMenuItem { Title = "ChurchPlus Records", Icon = "record.png", TargetType = typeof(RecordsList) },
                    new RootPageMenuItem { Title = "Watch ChurchPlus tutorial Videos", Icon = "youtube.png", TargetType = typeof(TutorialVideos) },
                    new RootPageMenuItem { Title = "About ChurchPlus", Icon = "aboutus.png", TargetType = typeof(AboutChurchplus) },

                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
