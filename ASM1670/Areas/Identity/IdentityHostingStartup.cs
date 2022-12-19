using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
[assembly: HostingStartup(typeof(ASM1670.Areas.Identity.IdentityHostingStartup))]
namespace ASM1670.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
