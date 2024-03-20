using AfstandCalculator.Data;
using AfstandCalculator.Models;
namespace AfstandCalculator.Views;

public partial class AlleAdressenPage : ContentPage
{
    VriendenDatabase Database;

    public Adres NewAdres { get; set; }


    public AlleAdressenPage(VriendenDatabase db)
	{
		InitializeComponent();
        Database = db;
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

    private void LVAdres_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

 
    private async void SaveAdresBtn_Clicked(object sender, EventArgs e)
    {
        if (NewAdres == null) 
        {
            Adres NewAdres = new Adres
            {
                Straat = EntryStraat.Text,
                Postcode = EntryPostcode.Text,
                Plaats = EntryPlaats.Text,
                Land = EntryLand.Text,
                
            };
            await Database.AddAdres(NewAdres);


        }
        else
        
        {
            await Database.UpdateAdres(NewAdres);


        }
        LVAdres.ItemsSource = await Database.GetAdresAsync();
    }

    private async void LVAdres_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var adres = (Adres)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Wijzig", "Verwijder");
    
    switch (action)
        {
            case "Wijzig"


        }

    
    }
}