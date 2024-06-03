using CommunityToolkit.Mvvm.ComponentModel;

namespace MembershipsDemo.Models
{
    public partial class Partner : AuditFields
    {
        [ObservableProperty]
        private string _name = default!;
        [ObservableProperty]
        private string _lastName = default!;
        [ObservableProperty]
        private string _email = default!;
        [ObservableProperty]
        private string _imageUrl = default!;
        [ObservableProperty]
        private string _phone = default!;
        [ObservableProperty]
        private string _emergencyPhone = default!;
        [ObservableProperty]
        private GenderType _gender;

        public override string ToString()
        {
            return string.Concat(Name, " ", LastName);
        }
        public string FullName { get => ToString(); }
    }
}
