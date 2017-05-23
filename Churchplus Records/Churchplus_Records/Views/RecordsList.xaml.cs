using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Churchplus_Records.Models;
using Churchplus_Records.Data;
using System.Diagnostics;

namespace Churchplus_Records.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordsList : ContentPage
    {
        public RecordsList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtRecordId = -1;
            ObservableCollection<Record> records = new ObservableCollection<Record>(App.Database.GetAllRecords());
            RecordsListView.ItemsSource = records;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async private void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SingleRecord());
        }

        async private void OnSingleRecordSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtRecordId = (e.SelectedItem as Record).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as Record).ID);
            await Navigation.PushAsync(new SingleRecord
            {
                BindingContext = e.SelectedItem as Record
            });


        }
    }



    //class RecordsListViewModel : INotifyPropertyChanged
    //{
    //    public ObservableCollection<Item> Items { get; }
    //    public ObservableCollection<Grouping<string, Item>> ItemsGrouped { get; }

    //    public RecordsListViewModel()
    //    {
    //        Items = new ObservableCollection<Item>(new[]
    //        {
    //            new Item { Text = "Baboon", Detail = "Africa & Asia" },
    //            new Item { Text = "Capuchin Monkey", Detail = "Central & South America" },
    //            new Item { Text = "Blue Monkey", Detail = "Central & East Africa" },
    //            new Item { Text = "Squirrel Monkey", Detail = "Central & South America" },
    //            new Item { Text = "Golden Lion Tamarin", Detail= "Brazil" },
    //            new Item { Text = "Howler Monkey", Detail = "South America" },
    //            new Item { Text = "Japanese Macaque", Detail = "Japan" },
    //        });

    //        var sorted = from item in Items
    //                     orderby item.Text
    //                     group item by item.Text[0].ToString() into itemGroup
    //                     select new Grouping<string, Item>(itemGroup.Key, itemGroup);

    //        ItemsGrouped = new ObservableCollection<Grouping<string, Item>>(sorted);

    //        RefreshDataCommand = new Command(
    //            async () => await RefreshData());
    //    }

    //    public ICommand RefreshDataCommand { get; }

    //    async Task RefreshData()
    //    {
    //        IsBusy = true;
    //        //Load Data Here
    //        await Task.Delay(2000);

    //        IsBusy = false;
    //    }

    //    bool busy;
    //    public bool IsBusy
    //    {
    //        get { return busy; }
    //        set
    //        {
    //            busy = value;
    //            OnPropertyChanged();
    //            ((Command)RefreshDataCommand).ChangeCanExecute();
    //        }
    //    }


    //    public event PropertyChangedEventHandler PropertyChanged;
    //    void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    //    public class Item
    //    {
    //        public string Text { get; set; }
    //        public string Detail { get; set; }

    //        public override string ToString() => Text;
    //    }

    //    public class Grouping<K, T> : ObservableCollection<T>
    //    {
    //        public K Key { get; private set; }

    //        public Grouping(K key, IEnumerable<T> items)
    //        {
    //            Key = key;
    //            foreach (var item in items)
    //                this.Items.Add(item);
    //        }
    //    }
    //}
}
