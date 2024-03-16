using AfstandCalculator.Data;
using AfstandCalculator.Models;

namespace AfstandCalculator.Views;

public partial class AlleVriendenPage : ContentPage
{
    VriendenDatabase Database;
    IConnectivity Connectivity;
    readonly Vriend vriend1;
    readonly Adres adres1;
    public AlleVriendenPage(VriendenDatabase db, IConnectivity connectivity)
    {
        InitializeComponent();
        Database = db;
        Connectivity = connectivity;
        //Database.GetVriendenAsync();
        Task.Run(async () => LVVrienden.ItemsSource = await db.GetVriendenAsync());
    }


    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
       // await Database.GetVriendenAsync();

        base.OnNavigatedTo(args);
        SearchBar.Text = string.Empty;


    }

    protected override async void OnAppearing()
    {
        await Database.GetVriendenAsync();

        base.OnAppearing();


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
/*           await Navigation.PushAsync(new AfstandtotvriendenPage(selectedItem.FullName, selectedItem.Telefoon, selectedItem.Adres,  Database));
*/            await Navigation.PushAsync(new AfstandtotvriendenPage(selectedItem, Database));

        }




    }
}