using Microsoft.Extensions.Logging;
using MauiApp1.DataAccess;
using MauiApp1.Pages;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-brands.otf", "FAB");
                fonts.AddFont("fa-regular.otf", "FAR");
                fonts.AddFont("fa-solid.otf", "FAS");
            });

		builder.Services.AddDbContext<TestDbContext>();
		builder.Services.AddTransient<ListPage>();

		var dbContext = new TestDbContext();
		dbContext.Database.EnsureCreated();
		dbContext.Dispose();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
