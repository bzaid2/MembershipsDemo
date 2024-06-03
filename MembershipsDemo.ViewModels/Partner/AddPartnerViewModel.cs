using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FluentValidation;
using MembershipsDemo.Interfaces;
using MembershipsDemo.Messenger;
using System.Windows.Input;

namespace MembershipsDemo.ViewModels.Partner
{
    public partial class AddPartnerViewModel : ObservableObject
    {
        private readonly IPartner PartnerService;
        private readonly IValidator<Models.Partner> validator;

        [ObservableProperty]
        private Models.Partner _Partner = new Models.Partner();

        public AddPartnerViewModel(
            IPartner _PartnerService,
            IValidator<Models.Partner> _validator)
        {
            PartnerService = _PartnerService;
            validator = _validator;
        }

        public ICommand AddCommand => new RelayCommand(Add);

        private async void Add()
        {
            var validatorResult = await validator.ValidateAsync(Partner);
            if (!validatorResult.IsValid)
            {
                foreach (var err in validatorResult.Errors)
                    WeakReferenceMessenger.Default.Send(new ChildSnackBarChangedMessage(err.ErrorMessage));
                return;
            }
            var result = await PartnerService.AddAsync(Partner);
            if (result)
            {
                WeakReferenceMessenger.Default.Send(new PartnerChangedMessage(Partner));
                WeakReferenceMessenger.Default.Send(new CloseRootDialogChangedMessage(true));
                WeakReferenceMessenger.Default.Send(new RootSnackBarChangedMessage($"Socio '{Partner.Name}' registrado exitosamente"));
            }
            else
                WeakReferenceMessenger.Default.Send(new ChildSnackBarChangedMessage("Ocurrió un error al registrar el socio"));
        }
    }
}
