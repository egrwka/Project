using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Oleinik.Models;
using Oleinik.Views;

namespace Oleinik.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public ListViewModel()
        {
            Title = "List";
            Items = new ObservableCollection<Item>();
            ExecuteReloadCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ListPage, Item>(this, "Update", async (obj, item) =>
            {
                await ExecuteLoadItemsCommand();
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
        public Command ExecuteReloadCommand { get; set; }
    }
}