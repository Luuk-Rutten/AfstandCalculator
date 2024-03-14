using AfstandCalculator.Data;
using AfstandCalculator.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace AfstandCalculator.Views;

public partial class VriendDetailPage : ContentPage
{
    public Vriend selectedItem { get; set;}

    Entry VoornaamEntryveld = new Entry();
    Entry AchternaamEntryveld = new Entry();
    public VriendDetailPage(Vriend selectedItem)
	{
		InitializeComponent();
        this.selectedItem = selectedItem;
        VoornaamEntryveld.Text = selectedItem.Voornaam.ToString();

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
/*        selectedItem.Voornaam = VoornaamEntryveld.Text;
        selectedItem.Achternaam = AchternaamEntryveld.Text;*/


    }


}