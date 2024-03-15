using AfstandCalculator.Data;
using AfstandCalculator.Models;
using AfstandCalculator.Services;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Maui.Graphics.Text;
using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace AfstandCalculator.Views;

public partial class AfstandtotvriendenPage : ContentPage
{
    VriendenDatabase Database;
   public  Vriend selectedItem {  get; set; }

    public List<Vriend> selectedFriends { get; set; }



    public AfstandtotvriendenPage(Vriend selectedItem, VriendenDatabase database)
    {
        InitializeComponent();
        this.selectedItem = selectedItem;
        Database = database;
        lblVriend.Text = selectedItem.FullName.ToString();
        lblTelefoon.Text = selectedItem.Telefoon.ToString();
        lblAdres.Text = selectedItem.Adres.Adresregel.ToString();
        //Task.Run(async () => LVafstandvrienden.ItemsSource = await Database.GetVriendenAsync());

}

protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

       await BerekenAfstand();

    }

    public async Task BerekenAfstand()
    {
        List<Vriend> VriendenfromDb = await Database.GetVriendenAsync();

        List<Vriend> LijstMetAfstanden = new List<Vriend> ();

        foreach (var vriend in VriendenfromDb)
        {
            if (vriend.VriendId != selectedItem.VriendId)
            {
                var AfstandTussenVrienden = await LocationService.GetDistanceBetweenPoints(selectedItem.Adres.Adresregel, vriend.Adres.Adresregel);
                vriend.Afstand = $"{AfstandTussenVrienden} KM";
                LijstMetAfstanden.Add(vriend);
            }
        }
        selectedFriends = LijstMetAfstanden;
        LVafstandvrienden.ItemsSource = selectedFriends;


    }



    private async void LVafstandvrienden_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // await Navigation.PushAsync(new VriendDetailPage(selectedItem));

        var selectedItem = e.SelectedItem as Vriend;

        if (selectedItem != null)
        {

            await Navigation.PushAsync(new VriendDetailPage(selectedItem, Database));

        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {


       await Navigation.PushAsync(new VriendDetailPage(selectedItem, Database));

    }
}
       