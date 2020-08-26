using System;
using System.Threading.Tasks;
using Oleinik.Models;
using Oleinik.Views;
using Xamarin.Forms;

namespace Oleinik.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
