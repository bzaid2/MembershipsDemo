using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MembershipsDemo.Messenger
{
    public class RootSnackBarChangedMessage : ValueChangedMessage<string>
    {
        public RootSnackBarChangedMessage(string value) : base(value)
        {
        }
    }
}
