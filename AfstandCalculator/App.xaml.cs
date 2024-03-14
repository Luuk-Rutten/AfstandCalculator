using AfstandCalculator.Data;
using AfstandCalculator.Views;

namespace AfstandCalculator
{
    public partial class App : Application
    {
        VriendenDatabase Database;
        public App(VriendenDatabase db, IConnectivity connectivity) 
        {
            InitializeComponent();
            Database = db;
            MainPage = new NavigationPage(new MainPage(Database, connectivity)); // We geven nu niet IConnectivity mee maar heb älleVriendenPage object heeft hier wel toegang toe. Deze pagina geeft het weer door naar ReisafstandNaarvrienden
        }


    }
}
