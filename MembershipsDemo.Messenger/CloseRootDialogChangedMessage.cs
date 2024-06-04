using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MembershipsDemo.Messenger
{
    public class CloseRootDialogChangedMessage : ValueChangedMessage<bool>
    {
        public CloseRootDialogChangedMessage(bool value) : base(value)
        {
        }
    }
}
