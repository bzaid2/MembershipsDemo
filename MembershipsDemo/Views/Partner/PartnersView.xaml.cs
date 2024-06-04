using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MembershipsDemo.Views.Partner
{
    /// <summary>
    /// Lógica de interacción para PartnersView.xaml
    /// </summary>
    public partial class PartnersView : UserControl
    {
        public PartnersView()
        {
            InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<ViewModels.Partner.PartnersViewModel>();
        }

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogHost.Show(
                new AddPartnerView(),
                "RootDialog",
                null,
                null,
                null);
        }

        private void PartnersGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            drawerHost.IsRightDrawerOpen = true;
            if (sender == null)
                return;
            var Partner = (sender as DataGrid).SelectedItem as Models.Partner;
            App.Current.ServiceProvider.GetService<ViewModels.Partner.UpdatePartnerViewModel>().Partner = Partner;
        }
    }
}
