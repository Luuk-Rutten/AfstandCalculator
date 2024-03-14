using AfstandCalculator.Data;
using AfstandCalculator.Views;

namespace AfstandCalculator
{
    public partial class MainPage : TabbedPage
    {
        VriendenDatabase Database;
        public MainPage(VriendenDatabase db, IConnectivity connectivity)
        {
            InitializeComponent();
            Database = db;
            var alleVriendenPage = new AlleVriendenPage(Database, connectivity);
            var alleAdressenPage = new AlleAdressenPage(Database);
            Children.Add(alleVriendenPage);
            Children.Add(alleAdressenPage);
            alleVriendenPage.IconImageSource = "persons.png";
            alleAdressenPage.IconImageSource = "address.png";
        }
    }

}
