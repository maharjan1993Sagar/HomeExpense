using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeExpense.Startup))]
namespace HomeExpense
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
