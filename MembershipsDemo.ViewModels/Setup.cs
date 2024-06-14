using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MembershipsDemo.ViewModels
{
    public class Setup
    {
        public static IServiceProvider ConfigureServices()
        {
            var sc = new ServiceCollection();

            // Services
            sc.AddSingleton<Interfaces.ILoggerManager, Plugins.LoggerManager>();
            sc.AddSingleton<Interfaces.IPartner, LiteDb.PartnerService>();

            // Validations
            sc.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Validators.PartnerValidation)));

            // ViewModels
            sc.AddTransient<Partner.AddPartnerViewModel>();
            sc.AddSingleton<Partner.PartnersViewModel>();
            sc.AddSingleton<Partner.UpdatePartnerViewModel>();

            return sc.BuildServiceProvider();
        }
    }
}
