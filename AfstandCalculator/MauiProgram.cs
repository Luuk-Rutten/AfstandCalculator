using AfstandCalculator.Data;
using Microsoft.Extensions.Logging;
using AfstandCalculator;
using Microsoft.EntityFrameworkCore;
using AfstandCalculator.Views;

namespace AfstandCalculator
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            string SQLiteDbPath = Constanten.GetDatabaseFilePath();
            builder.Services.AddDbContext<VriendenContext>(
                opt => opt.UseSqlite($"Data Source={SQLiteDbPath}")
            );
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddScoped<VriendenDatabase>();
            return builder.Build();
        }
    }
}
