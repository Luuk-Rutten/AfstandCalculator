using AfstandCalculator.Data;
using AfstandCalculator.Models;
using System.IO;
namespace AfstandCalculator.Views;

public partial class AlleAdressenPage : ContentPage
{
    VriendenDatabase Database;

    //private Adres SelectedAdres;

    public Adres? SelectedAdres { get; set; }


    public AlleAdressenPage(VriendenDatabase db)
    {
        InitializeComponent();
        Database = db;
        SelectedAdres = new Adres();  
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);



    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        LVAdres.ItemsSource = await Database.GetAdresAsync();

    }


    private async void SaveAdresBtn_Clicked(object sender, EventArgs e)
    {



        if (EntryStraat.Text == "" || EntryPostcode.Text == "" || EntryPlaats.Text == "" || EntryLand.Text == "")
        {
            await DisplayAlert("Foute invoer", "Vul alle velden in", "Oke");
        }
        else if (SelectedAdres.AdresId == 0)
        {
           
                
                SelectedAdres.Straat = EntryStraat.Text;
                SelectedAdres.Postcode = EntryPostcode.Text;
                SelectedAdres.Plaats = EntryPlaats.Text;
                SelectedAdres.Land = EntryLand.Text;

                   
            await Database.AddAdres(SelectedAdres);
        }


                else
                {

            SelectedAdres.Straat = EntryStraat.Text;
            SelectedAdres.Postcode = EntryPostcode.Text;
            SelectedAdres.Plaats = EntryPlaats.Text;
            SelectedAdres.Land = EntryLand.Text;
            await Database.UpdateAdres(SelectedAdres);

        }

        SelectedAdres = null;

        LVAdres.ItemsSource = await Database.GetAdresAsync();

        EntryStraat.Text = "";
        EntryPostcode.Text = "";
        EntryPlaats.Text = "";
        EntryLand.Text = "";

            
            }


    private async void LVAdres_ItemTapped(object sender, ItemTappedEventArgs e)
    {    
         SelectedAdres = (Adres)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Wijzig", "Verwijder");
    
    switch (action)
        {
            case "Wijzig":
            EntryStraat.Text = SelectedAdres.Straat;
                EntryPostcode.Text = SelectedAdres.Postcode;
                EntryPlaats.Text = SelectedAdres.Plaats;
                EntryLand.Text = SelectedAdres.Land;
                break;

            case "Verwijder":

                await Database.DeleteAdres(SelectedAdres);
                LVAdres.ItemsSource = await Database.GetAdresAsync();
                
                break;
                                
        }

    
    }
}
