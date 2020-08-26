using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Oleinik.Models;
using Oleinik.ViewModels;

namespace Oleinik.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        ItemDetailViewModel viewModel;
        public NewItemPage(ItemDetailViewModel viewModelG)
        {
            InitializeComponent();
            viewModel = viewModelG;
            if (viewModel != null)
            {
                this.Title = "Update Item";
                btn.Text = "Update";
                btn.Clicked += Update_Clicked;
                BindingContext = viewModel;
            }
            else
            {
                btn.Clicked += Save_Clicked;
            }
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if(name.Text.Trim() != "" && desc.Text.Trim() != "")
            {
                App.ItemDatabase.SaveItem(new Item { Text = name.Text, Description = desc.Text });
            }
            await Navigation.PopModalAsync(); 
        }

        async void Update_Clicked(object sender, EventArgs e)
        {
            if (name.Text.Trim() != "" && desc.Text.Trim() != "")
            {
                App.ItemDatabase.UpdateItem(new Item { Id = viewModel.Item.Id, Text = name.Text, Description = desc.Text });
            }
            await Navigation.PopModalAsync(); 
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}