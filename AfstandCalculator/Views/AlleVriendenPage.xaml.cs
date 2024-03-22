using AfstandCalculator.Data;
using AfstandCalculator.Models;
using Microsoft.Maui.Networking;

namespace AfstandCalculator.Views;

public partial class AlleVriendenPage : ContentPage
{
    VriendenDatabase Database;
    IConnectivity Connectivity;


    public AlleVriendenPage(VriendenDatabase db, IConnectivity connectivity)
    {
        InitializeComponent();
        Database = db;
        Connectivity = connectivity;
    }

    public AlleVriendenPage(VriendenDatabase database)
    {
        InitializeComponent();
        Database = database;

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {

        base.OnNavigatedTo(args);



    }

    protected override async void OnAppearing()
    {

        base.OnAppearing();
        LVVrienden.ItemsSource = await Database.GetVriendenAsync();
        SearchBar.Text = string.Empty;

    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var vrienden = Database.SearchVriendenAsync(((SearchBar)sender).Text);
        LVVrienden.ItemsSource = vrienden;
    }

    private async void LVVrienden_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
       var selectedItem =  e.SelectedItem as Vriend;

        if (selectedItem != null)
        {
           await Navigation.PushAsync(new AfstandtotvriendenPage(selectedItem, Database, Connectivity));

        }

    }

    private async void NewItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VriendDetailPage2(Database));
    }
}