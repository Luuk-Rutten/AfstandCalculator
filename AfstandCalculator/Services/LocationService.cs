using System.Net.Sockets;
using System.Text.Json;
using AfstandCalculator;


namespace AfstandCalculator.Services
{
    public static class LocationService
    {

        public static async Task<double> GetDistanceBetweenPoints(string startLocation, string endLocation)
 {
     if (IsInternetAvailable())
     {
         string requestUrl = $"http://dev.virtualearth.net/REST/V1/Routes/Driving?wp.0={startLocation}&wp.1={endLocation}&key={Constanten.BingMapsKey}";

         using (HttpClient client = new HttpClient())
         {
             try
             {
                 HttpResponseMessage response = await client.GetAsync(requestUrl);
                 if (response.IsSuccessStatusCode)
                 {
                     string content = await response.Content.ReadAsStringAsync();
                     JsonDocument jsonResponse = JsonDocument.Parse(content);
                     double distance = jsonResponse.RootElement.GetProperty("resourceSets")[0].GetProperty("resources")[0].GetProperty("travelDistance").GetDouble();
                            
                     return Math.Round(distance, 1);
                 }
                 else
                 {
                     return 0.0;
                 }

             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
                 return 0.0;
             }
         }
     }
     return -1; // Een -1 geeft hier aan dat de methode niet gelukt is. Een 0 kan betekenen dat beide adressen identiek zijn. 
 }

 public static bool IsInternetAvailable()
 {
     NetworkAccess accessType = Connectivity.Current.NetworkAccess;

     if (accessType == NetworkAccess.Internet)
     {
         return true;
     }
     return false;
 }


    }
}
