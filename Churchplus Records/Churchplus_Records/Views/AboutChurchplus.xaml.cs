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

namespace Churchplus_Records.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutChurchplus : ContentPage
    {
        public AboutChurchplus()
        {
            InitializeComponent();
            webView.Source = "http://churchplus.co";
            //BindingContext = new ContentPageViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await progressBar.ProgressTo(0.9, 900, Easing.SpringIn);

        }
        private void webView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            progressBar.IsVisible = true;
        }

        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            progressBar.IsVisible = false;

        }
    }

    class AboutChurchplusViewModel : INotifyPropertyChanged
    {

        public AboutChurchplusViewModel()
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
