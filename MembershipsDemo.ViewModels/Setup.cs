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
            sc.AddSingleton<Interfaces.IPartner, LiteDb.PartnerService>();

            // Validations
            sc.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Validators.PartnerValidation)));

            // ViewModels
            sc.AddTransient<ViewModels.Partner.AddPartnerViewModel>();

            return sc.BuildServiceProvider();
        }
    }
}
