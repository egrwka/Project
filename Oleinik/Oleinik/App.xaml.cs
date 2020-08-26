using Xamarin.Forms;
using Oleinik.Views;
using Oleinik.Data;

namespace Oleinik
{
    public partial class App : Application
    {
        static ItemDatabaseController itemDatabase;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static ItemDatabaseController ItemDatabase
        {
            get
            {
                if(itemDatabase == null)
                {
                    itemDatabase = new ItemDatabaseController();
                }
                return itemDatabase;
            }
        }
    }
}
