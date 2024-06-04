using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MembershipsDemo.Views.Partner
{
    /// <summary>
    /// Lógica de interacción para UpdatePartnerView.xaml
    /// </summary>
    public partial class UpdatePartnerView : UserControl
    {
        public UpdatePartnerView()
        {
            InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<ViewModels.Partner.UpdatePartnerViewModel>();
        }

        private void btdDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogHost.Show(
                new PartnerDeleteConfirmationView(),
                "RootDialog",
                null,
                null,
                null);
        }
    }
}
