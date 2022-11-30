using homework_2.Database;
using homework_2.Services.Friends;
using Microsoft.EntityFrameworkCore;

namespace homework_2
{
    public class ServicesConfiguration
    {
        public static void Bind(WebApplicationBuilder builder)
        {
            AddDatabase(builder);
            SetDefault(builder.Services);

            if (builder.Environment.IsProduction())
                SetProduction(builder.Services);

            if(builder.Environment.IsDevelopment())
                SetDevelopment(builder.Services);
        }

        private static void AddDatabase(WebApplicationBuilder builder)
        {
            string? friendDbConnectString = builder.Configuration.GetConnectionString("FriendDb");
            builder.Services.AddDbContext<FriendContext>(optionsAction =>
            optionsAction.UseSqlServer(friendDbConnectString));
        }

        private static void SetDefault(IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllersWithViews();
        }

        private static void SetProduction(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IFriendsService, FriendsDbService>();
        }

        private static void SetDevelopment(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IFriendsService, StubFriendsService>();
        }
    }
}
