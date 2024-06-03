using CommunityToolkit.Mvvm.ComponentModel;

namespace MembershipsDemo.Models
{
    public partial class AuditFields: ObservableObject
    {
        [ObservableProperty]
        private int _id;
        [ObservableProperty]
        private string _createdBy = default!; // UserName
        [ObservableProperty]
        private DateTime _createdAt;
        [ObservableProperty]
        private DateTime _updatedAt;
        [ObservableProperty]
        private string _updatedBy = default!;
    }
}
