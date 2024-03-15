using AfstandCalculator.Data;
using AfstandCalculator.Models;
using AfstandCalculator.Services;
using System.Collections.Generic;

namespace AfstandCalculator.Views;

public partial class VriendDetailPage2 : ContentPage
{
    VriendenDatabase Database;

    public List<Adres> AdresList { get; set; }


    public Vriend selectedItem { get; set; }


    public VriendDetailPage2(Vriend selectedItem, VriendenDatabase database)
    {
        InitializeComponent();
        this.selectedItem = selectedItem;
        Database = database;
        VoornaamEntryveld.Text = selectedItem.Voornaam;
        AchternaamEntryveld.Text = selectedItem.Achternaam;
        TelefoonEntryveld.Text = selectedItem.Telefoon;
        AdresEntryveld.Text = selectedItem.Adres.Adresregel;

        Task.Run(async () => AdresPicker.ItemsSource = await Database.GetAdresAsync());

        
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);



    }

    private void AdresPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedItem.Adres = (Adres)AdresPicker.SelectedItem;
        AdresEntryveld.Text = selectedItem.Adres.Adresregel;

    }
}
