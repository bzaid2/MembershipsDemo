using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MembershipsDemo.Views.Partner
{
    /// <summary>
    /// Lógica de interacción para PartnerDeleteConfirmationView.xaml
    /// </summary>
    public partial class PartnerDeleteConfirmationView : UserControl
    {
        public PartnerDeleteConfirmationView()
        {
            InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<ViewModels.Partner.UpdatePartnerViewModel>();
        }
    }
}
