using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Oleinik.Models;
using Oleinik.Views;
using Oleinik.ViewModels;

namespace Oleinik.Views
{
    [DesignTimeVisible(false)]
    public partial class ListPage : ContentPage
    {
        ListViewModel viewModel;

        public ListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage(null)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage(new ItemDetailViewModel(item))));
        }

        async void Remove_Clicked(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            App.ItemDatabase.DeleteItem(item);
        }
    }
}