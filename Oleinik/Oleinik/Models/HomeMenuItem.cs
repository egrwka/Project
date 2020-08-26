using System;
using System.Collections.Generic;
using System.Text;

namespace Oleinik.Models
{
    public enum MenuItemType
    {
        Search,
        List
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
