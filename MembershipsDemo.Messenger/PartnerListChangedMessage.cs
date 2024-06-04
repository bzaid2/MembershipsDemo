using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MembershipsDemo.Messenger
{
    public class PartnerListChangedMessage : ValueChangedMessage<bool>
    {
        public PartnerListChangedMessage(bool value) : base(value)
        {
        }
    }
}
