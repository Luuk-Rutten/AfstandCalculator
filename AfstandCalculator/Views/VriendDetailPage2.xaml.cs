using AfstandCalculator.Data;
using AfstandCalculator.Models;
using AfstandCalculator.Services;
using System.Collections.Generic;

namespace AfstandCalculator.Views;

public partial class VriendDetailPage2 : ContentPage
{
    VriendenDatabase Database;

    public List<Adres> AdresList { get; set; }


    public Vriend SelectedVriend { get; set; }


    public VriendDetailPage2(Vriend selectedItem, VriendenDatabase database)
    {
        InitializeComponent();
        this.SelectedVriend = selectedItem;
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
      //  this.SelectedVriend = SelectedVriend;



    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
       // this.SelectedVriend = SelectedVriend;

    }

    private void AdresPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedVriend.Adres = (Adres)AdresPicker.SelectedItem;
        AdresEntryveld.Text = SelectedVriend.Adres.Adresregel;

    }



    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        await Database.Update(SelectedVriend);
                {
            SelectedVriend.Voornaam = VoornaamEntryveld.Text;
            SelectedVriend.Achternaam = AchternaamEntryveld.Text;
                    SelectedVriend.Telefoon = TelefoonEntryveld.Text;
            SelectedVriend.Adres = SelectedVriend.Adres;

                }
        
     }
        
 

    private void AdresSwitch_Toggled(object sender, ToggledEventArgs e)
    {

    }
}
