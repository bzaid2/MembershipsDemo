using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MembershipsDemo.Views.Partner
{
    /// <summary>
    /// Lógica de interacción para AddPartnerView.xaml
    /// </summary>
    public partial class AddPartnerView : UserControl
    {
        public AddPartnerView()
        {
            InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<ViewModels.Partner.AddPartnerViewModel>();
        }
    }
}
