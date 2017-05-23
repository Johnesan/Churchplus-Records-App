using Churchplus_Records.Models;
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
    public partial class SingleRecord : ContentPage
    {
        public SingleRecord()
        {
            InitializeComponent();
            BindingContext = new Record();
        }
        async public void OnSaveClicked(Object sender, EventArgs e)
        {
            var record = (Record)BindingContext;
            App.Database.SaveRecord(record);
            await Navigation.PopAsync();

        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var record = (Record)BindingContext;
            App.Database.DeleteRecord(record);
            await Navigation.PopAsync();
        }
        async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }



    class SingleRecordViewModel : INotifyPropertyChanged
    {

        public SingleRecordViewModel()
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
