using AfstandCalculator.Data;
using AfstandCalculator.Models;
using AfstandCalculator.Services;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Maui.Graphics.Text;
using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AfstandCalculator.Views;

public partial class AfstandtotvriendenPage : ContentPage
{
    VriendenDatabase Database;
   public  Vriend selectedItem {  get; set; }

    public List<Vriend> selectedFriends { get; set; }


    NetworkAccess accessType = Connectivity.Current.NetworkAccess;


    public AfstandtotvriendenPage(Vriend selectedItem, VriendenDatabase database, IConnectivity connectivity)
    {
        InitializeComponent();

        this.selectedItem = selectedItem;
        Database = database;
 

}

    public AfstandtotvriendenPage(VriendenDatabase database)
    {
        InitializeComponent();
        Database = database;

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
       // this.selectedItem = selectedItem;

        await BerekenAfstand();
        await PopulateLabel();

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
       // this.selectedItem = selectedItem;

        await BerekenAfstand();
        await PopulateLabel();


    }
    public async Task PopulateLabel()
    {
        LVafstandvrienden.ItemsSource = selectedFriends;
        lblVriend.Text = selectedItem.FullName.ToString();
        lblTelefoon.Text = selectedItem.Telefoon.ToString();

        if (selectedItem.Adres == null)
        {
            lblAdres.Text = "Geen adres opgegeven.";
        }
        else
        {
            lblAdres.Text = selectedItem.Adres.Adresregel.ToString();
        }

    }
  

    public async Task BerekenAfstand()
    {
        List<Vriend> VriendenfromDb = await Database.GetVriendenAsync();

        List<Vriend> LijstMetAfstanden = new List<Vriend> ();

        if (accessType != NetworkAccess.Internet)
        {
            await DisplayAlert("Geen internet", "Controleer de internetverbinding!", "OK");

        }
        else
        {

            foreach (var vriend in VriendenfromDb)
            {
                if (vriend.VriendId != selectedItem.VriendId && selectedItem.Adres != null && vriend.Adres != null)
                {
                    var AfstandTussenVrienden = await LocationService.GetDistanceBetweenPoints(selectedItem.Adres.Adresregel, vriend.Adres.Adresregel);
                    vriend.Afstand = $"{AfstandTussenVrienden} KM";
                    LijstMetAfstanden.Add(vriend);
                }
            }
            selectedFriends = LijstMetAfstanden;
            LVafstandvrienden.ItemsSource = selectedFriends;

        }
    }



    private async void LVafstandvrienden_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

        Vriend? selectedItem = e.SelectedItem as Vriend;
        if (selectedItem != null)
        {

            await Navigation.PushAsync(new VriendDetailPage2(selectedItem, Database));

        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

     
        await Navigation.PushAsync(new VriendDetailPage2(selectedItem, Database));

    }
}
       
