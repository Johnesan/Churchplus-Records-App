using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.Models;

namespace Churchplus_Records.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleYoutubeVideo : ContentPage
    {

        public SingleYoutubeVideo()
        {
            InitializeComponent();
            BindingContext = new YoutubeItem();

            //youtubeItem = (YoutubeItem)BindingContext;
            youtubeVideo.Source = "https://www.youtube.com/embed/" + videoId;


        }
        public SingleYoutubeVideo(YoutubeItem youtubeItem)
        {
            InitializeComponent();
            BindingContext = new YoutubeItem();

            var videoId = youtubeItem.VideoId;

            //youtubeItem = (YoutubeItem)BindingContext;
            youtubeVideo.Source = "https://www.youtube.com/embed/" + videoId;


        }

        private void youtubeVideo_Navigating(object sender, WebNavigatingEventArgs e)
        {

        }

        private void youtubeVideo_Navigated(object sender, WebNavigatedEventArgs e)
        {

        }
    }

    class SingleYoutubeVideoViewModel : INotifyPropertyChanged
    {

        public SingleYoutubeVideoViewModel()
        {
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }

        public ICommand IncreaseCountCommand { get; }

        void IncreaseCount() =>
            CountDisplay = $"You clicked {++count} times";


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
