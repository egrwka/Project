using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Oleinik.Models;
using Oleinik.Views;

namespace Oleinik.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public SearchViewModel()
        {
            Title = "Search";
            Items = new ObservableCollection<Item>();
            ExecuteReloadCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<SearchPage, string>(this, "Search", async (obj, item) =>
            {
                await ExecuteLoadItemsCommand(item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = App.ItemDatabase.GetItems();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadItemsCommand(string search)
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = App.ItemDatabase.GetItems(search);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public Command ExecuteReloadCommand { get; set; }
    }
}