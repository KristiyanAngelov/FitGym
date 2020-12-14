using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FitGym.Web.Areas.Identity.IdentityHostingStartup))]

namespace FitGym.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
