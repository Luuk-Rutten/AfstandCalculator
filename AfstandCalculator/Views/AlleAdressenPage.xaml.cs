using AfstandCalculator.Data;
namespace AfstandCalculator.Views;

public partial class AlleAdressenPage : ContentPage
{
    VriendenDatabase Database;
    public AlleAdressenPage(VriendenDatabase db)
	{
		InitializeComponent();
        Database = db;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        LVAdres.ItemsSource = await Database.GetVriendenAsync();
        

    }

    private void LVAdres_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}