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
using XamarinForms.ViewModels;

namespace Churchplus_Records.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialVideos : ContentPage
    {
        public TutorialVideos()
        {
            InitializeComponent();
            BindingContext = new YoutubeViewModel();
        }

        private async void OnSingleVideoSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var youtubeItem = e.SelectedItem as YoutubeItem;

            await Navigation.PushAsync(new SingleYoutubeVideo(youtubeItem)
            {
                BindingContext = e.SelectedItem as YoutubeItem

            });

        }
    }


}
