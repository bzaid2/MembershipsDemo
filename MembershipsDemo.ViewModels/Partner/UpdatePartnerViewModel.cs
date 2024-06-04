using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FluentValidation;
using System.Windows.Input;
using MembershipsDemo.Interfaces;
using MembershipsDemo.Messenger;

namespace MembershipsDemo.ViewModels.Partner
{
    public partial class UpdatePartnerViewModel : ObservableObject
    {
        private readonly IPartner partnerService;
        private readonly IValidator<Models.Partner> validator;

        private Models.Partner _partner = new Models.Partner();

        public UpdatePartnerViewModel(
            IPartner _PartnerService,
            IValidator<Models.Partner> _validator)
        {
            partnerService = _PartnerService;
            validator = _validator;
        }

        public ICommand DeleteCommand => new RelayCommand(Delete);
        public ICommand UpdateCommand => new RelayCommand(Update);

        private async void Delete()
        {
            var result = await partnerService.DeleteAsync(Partner.Id);
            if (result)
            {
                WeakReferenceMessenger.Default.Send(new PartnerChangedMessage(Partner));
                WeakReferenceMessenger.Default.Send(new CloseRootDialogChangedMessage(true));
                WeakReferenceMessenger.Default.Send(new RootSnackBarChangedMessage("Cliente eliminado"));
                Partner = new Models.Partner();
            }
            else
                WeakReferenceMessenger.Default.Send(new ChildSnackBarChangedMessage("Ocurrió un error al eliminar el cliente"));
        }

        private async void Update()
        {
            var validatorResult = await validator.ValidateAsync(Partner);
            if (!validatorResult.IsValid)
            {
                foreach (var err in validatorResult.Errors)
                    WeakReferenceMessenger.Default.Send(new RootSnackBarChangedMessage(err.ErrorMessage));
                return;
            }
            var result = await partnerService.UpdateAsync(Partner);
            if (result)
            {
                WeakReferenceMessenger.Default.Send(new PartnerChangedMessage(Partner));
                WeakReferenceMessenger.Default.Send(new RootSnackBarChangedMessage("Cliente actualizado"));
            }
            else
                WeakReferenceMessenger.Default.Send(new ChildSnackBarChangedMessage("Ocurrió un error al actualizar el cliente"));
        }

        public Models.Partner Partner 
        { 
            get => _partner;
            set
            {
                SetProperty(ref _partner, value);
            }
        }
    }
}
