using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MembershipsDemo.Messenger
{
    public class ChildSnackBarChangedMessage : ValueChangedMessage<string>
    {
        public ChildSnackBarChangedMessage(string value) : base(value)
        {
        }
    }
}
