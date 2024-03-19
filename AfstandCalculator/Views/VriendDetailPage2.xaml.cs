using AfstandCalculator.Data;
using AfstandCalculator.Models;
using AfstandCalculator.Services;
using System.Collections.Generic;

namespace AfstandCalculator.Views;

public partial class VriendDetailPage2 : ContentPage
{
    VriendenDatabase Database;

  

    public Vriend SelectedVriend { get; set; }

    public Adres SelectedAdres { get; set; }

    //string newadres;

    public VriendDetailPage2(Vriend selectedItem, VriendenDatabase database)
    {
        InitializeComponent();
        this.SelectedVriend = selectedItem;
        Database = database;

        VoornaamEntryveld.Text = selectedItem.Voornaam;
        AchternaamEntryveld.Text = selectedItem.Achternaam;
        TelefoonEntryveld.Text = selectedItem.Telefoon;
        AdresEntryveld.Text = selectedItem.Adres.Adresregel;
        StraatEntryveld.Text = selectedItem.Adres.Straat;
        PostcodeEntryveld.Text = selectedItem.Adres.Postcode;
        PlaatsEntryveld.Text = selectedItem.Adres.Plaats;
        LandEntryveld.Text = selectedItem.Adres.Land;

    }




    public VriendDetailPage2(VriendenDatabase database)
    {
        InitializeComponent();
        Database = database;
        SelectedVriend = new Vriend();
 
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        AdresPicker.ItemsSource = await Database.GetAdresAsync();

        StraatEntry.IsEnabled = false;
        PostcodeEntry.IsEnabled = false;
        StadEntry.IsEnabled = false;
        LandEntry.IsEnabled = false;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

    }

    private void AdresPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedVriend.Adres = (Adres)AdresPicker.SelectedItem;
        //AdresEntryveld.Text = SelectedVriend.Adres.Adresregel;
        StraatEntryveld.Text = SelectedVriend.Adres.Straat;
        PostcodeEntryveld.Text = SelectedVriend.Adres.Postcode;
        PlaatsEntryveld.Text = SelectedVriend.Adres.Plaats;
        LandEntryveld.Text = SelectedVriend.Adres.Land;
    }



    private async void SaveButton_Clicked(object sender, EventArgs e)
    {


        if (VoornaamEntryveld.Text == "" || AchternaamEntryveld.Text == "" || TelefoonEntryveld.Text == "")
        {
            await DisplayAlert("Foute invoer", "Vul alle velden in", "Oke");
        }
        else
        {

            SelectedVriend.Voornaam = VoornaamEntryveld.Text;
            SelectedVriend.Achternaam = AchternaamEntryveld.Text;
            SelectedVriend.Telefoon = TelefoonEntryveld.Text;

            if  (SelectedVriend.Adres == null )
            {
                Adres SelectedAdres = new Adres(){
                    Straat = StraatEntryveld.Text,
                    Postcode = PostcodeEntryveld.Text,
                    Plaats = PlaatsEntryveld.Text,
                    Land = LandEntryveld.Text,
                };
                SelectedVriend.Adres = SelectedAdres;


            }
            }
        CheckAdres();
        await Database.Update(SelectedVriend);

    }

    

    private void AdresSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (AdresSwitch.IsToggled == true)
        {
            StraatEntry.IsEnabled = true;
            PostcodeEntry.IsEnabled = true;
            StadEntry.IsEnabled = true;
            LandEntry.IsEnabled = true;

        }
        else
        {
            StraatEntry.IsEnabled = false;
            PostcodeEntry.IsEnabled = false;
            StadEntry.IsEnabled = false;
            LandEntry.IsEnabled = false;

        }
    }

    public async void CheckAdres()
    {
        if (AdresSwitch.IsToggled == true)
        {
            if (StraatEntry.Text == "" || PostcodeEntry.Text == "" || StadEntry.Text == "" || LandEntry.Text == "")
            {
                await DisplayAlert("Foute invoer", "Vul alle velden in", "Oke");
            }
            else
            {
               // await Database.Update(SelectedVriend);
                
                    SelectedVriend.Adres.Straat = StraatEntry.Text;
                    SelectedVriend.Adres.Postcode = PostcodeEntry.Text;
                    SelectedVriend.Adres.Plaats = StadEntry.Text;
                    SelectedVriend.Adres.Land = LandEntry.Text;

                StraatEntryveld.Text = StraatEntry.Text ;
                PostcodeEntryveld.Text = PostcodeEntry.Text;
                PlaatsEntryveld.Text = StadEntry.Text;
                LandEntryveld.Text = LandEntry.Text;

            }
        }
       
        }


}





