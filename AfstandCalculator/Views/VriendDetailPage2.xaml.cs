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

    string newadres;

    public VriendDetailPage2(Vriend selectedItem, VriendenDatabase database)
    {
        InitializeComponent();
        this.SelectedVriend = selectedItem;
        Database = database;
        VoornaamEntryveld.Text = selectedItem.Voornaam;
        AchternaamEntryveld.Text = selectedItem.Achternaam;
        TelefoonEntryveld.Text = selectedItem.Telefoon;
        AdresEntryveld.Text = selectedItem.Adres.Adresregel;
                
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
        AdresEntryveld.Text = SelectedVriend.Adres.Adresregel;

    }



    private async void SaveButton_Clicked(object sender, EventArgs e)
    {

        if (SelectedVriend == null)


        {
            if (VoornaamEntryveld.Text == "" || AchternaamEntryveld.Text == "" || TelefoonEntryveld.Text == "" /*|| AdresEntryveld.Text == ""*/)
            {
                await DisplayAlert("Foute invoer", "Vul alle velden in", "Oke");
            }
            else
            {
                VoornaamEntryveld.Text = SelectedVriend.Voornaam;
                AchternaamEntryveld.Text = SelectedVriend.Achternaam;
                TelefoonEntryveld.Text = SelectedVriend.Telefoon;

                /*                newadres = $"{StraatEntryveld.Text}, {PostcodeEntryveld.Text}, {PlaatsEntryveld.Text}, {LandEntryveld.Text}";

                                Vriend newvriend = new Vriend();
                                newadres = $"{newvriend.Adres.Adresregel}";
                                VoornaamEntryveld.Text = newvriend.Voornaam;
                                AchternaamEntryveld.Text = newvriend.Achternaam;
                                TelefoonEntryveld.Text = newvriend.Telefoon;

                                await Database.AddVriend(newvriend);
                                {


                                    Voornaam = VoornaamEntryveld.Text,
                                    Achternaam = AchternaamEntryveld.Text,
                                    Telefoon = TelefoonEntryveld.Text,


                                });*/
            }
        }

            
           else // if (SelectedVriend != null)
            {

                SelectedVriend.Voornaam = VoornaamEntryveld.Text;
                SelectedVriend.Achternaam = AchternaamEntryveld.Text;
                SelectedVriend.Telefoon = TelefoonEntryveld.Text;

                CheckAdres();
                await Database.Update(SelectedVriend);

            }
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
                {
                    SelectedVriend.Adres.Straat = StraatEntry.Text;
                    SelectedVriend.Adres.Postcode = PostcodeEntry.Text;
                    SelectedVriend.Adres.Plaats = StadEntry.Text;
                    SelectedVriend.Adres.Land = LandEntry.Text;

                    AdresEntryveld.Text = $"{SelectedVriend.Adres.Adresregel}";             
                }

            }
        }
       


        }

    private void VoornaamEntryveld_TextChanged(object sender, TextChangedEventArgs e)
    {


    }

}





