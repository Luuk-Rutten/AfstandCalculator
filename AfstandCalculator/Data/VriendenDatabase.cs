
using Microsoft.EntityFrameworkCore;
using AfstandCalculator.Models;
using System.Collections;
namespace AfstandCalculator.Data;

public class VriendenDatabase : IDisposable
{

    VriendenContext Database;

    public VriendenDatabase(VriendenContext database)
    {
        Database = database;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Vriend>> GetVriendenAsync()
    {
        return await Database.Vrienden.Include(v => v.Adres).ToListAsync();
    }

    public async Task<List<Adres>> GetAdresAsync()
    {
        return await Database.Adressen.ToListAsync();
    }


    public IEnumerable<Vriend> SearchVriendenAsync(string InputText)
    {
        var Vrienden = Database.Vrienden;

        var vrienden = Vrienden.Where(x => !string.IsNullOrWhiteSpace(x.Voornaam) && x.Voornaam.StartsWith(InputText))?.ToList();

        if (vrienden == null || vrienden.Count <= 0)
        {
            vrienden = Database.Vrienden.Where(x => !string.IsNullOrWhiteSpace(x.Achternaam) && x.Achternaam.StartsWith(InputText))?.ToList();
        }
        return vrienden;
    }

}