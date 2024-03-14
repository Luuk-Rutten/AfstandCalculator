using AfstandCalculator.Data;
namespace AfstandCalculator.Views;

public partial class AlleAdressenPage : ContentPage
{ 

    public AlleAdressenPage(VriendenDatabase db)
	{
		InitializeComponent();
        Task.Run(async () => LVAdres.ItemsSource = await db.GetVriendenAsync());
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    private void LVAdres_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}