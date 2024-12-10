using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SmarTest.DataLayer;
using SmarTest.DataLayer.Models;
using SmarTest.Services;
using SmarTest.Services.Interfaces;
using SmarTest.WinUI;

namespace SmarTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            //please ignore the next 3 lines
            var mongoDbConnectionString = "mongodb+srv://andreiberes2002:8Utm6B0LmYtqqug8@smartestcluster.3bh02.mongodb.net/";
            var dataBaseName = "SmarTest";
            var mongoClient = new MongoClient(mongoDbConnectionString);
            
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            builder.Services.AddDbContext<SmarTestDbContext>(options =>
            {
                options.UseMongoDB(mongoDbConnectionString, dataBaseName);
            });
            builder.Services.AddMauiBlazorWebView();
            
#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddSingleton<IAuthService, AuthService>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IStudentClassService, StudentClassService>();

            return builder.Build();
        }
    }
}
