using CommunityToolkit.Mvvm.Messaging.Messages;
using MembershipsDemo.Models;

namespace MembershipsDemo.Messenger
{
    public class PartnerChangedMessage : ValueChangedMessage<Partner>
    {
        public PartnerChangedMessage(Partner value) : base(value)
        {
        }
    }
}
