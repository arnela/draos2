using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rent_a_car.Startup))]
namespace Rent_a_car
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
