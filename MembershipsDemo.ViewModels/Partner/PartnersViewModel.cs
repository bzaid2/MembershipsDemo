using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MembershipsDemo.Interfaces;
using MembershipsDemo.Messenger;

namespace MembershipsDemo.ViewModels.Partner
{
    public partial class PartnersViewModel : ObservableObject
    {
        private readonly IPartner partnerService;

        [ObservableProperty]
        private List<Models.Partner> _partners = new List<Models.Partner>();
        [ObservableProperty]
        private bool _isLoading = false;

        public PartnersViewModel(
            IPartner _partnerService)
        {
            partnerService = _partnerService;
            WeakReferenceMessenger.Default.Register<PartnerChangedMessage>(this, (r, m) => LoadPartners());
            LoadPartners();
        }

        private void LoadPartners()
        {
            IsLoading = true;
            Task.Run(async () =>
            {
                var result = await partnerService.FindAllAsync();
                Partners = result.ToList();
                IsLoading = false;
                WeakReferenceMessenger.Default.Send(new PartnerListChangedMessage(true));
            });
        }
    }
}
