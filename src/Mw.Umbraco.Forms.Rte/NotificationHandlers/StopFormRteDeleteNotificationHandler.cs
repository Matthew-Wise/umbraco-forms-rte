using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Mw.Umbraco.Forms.Rte.NotificationHandlers
{
    public class StopFormRteDeleteNotificationHandler : INotificationHandler<DataTypeDeletingNotification>
    {
        private readonly ILocalizedTextService _localizedTextService;

        public StopFormRteDeleteNotificationHandler(ILocalizedTextService localizedTextService)
        {
            _localizedTextService = localizedTextService;
        }

        public void Handle(DataTypeDeletingNotification notification)
        {
            foreach (var dt in notification.DeletedEntities)
            {
                if (dt.Name == FormsRteConstants.DataTypeName && notification.Cancel)
                {
                    notification.CancelOperation(new EventMessage("Error", _localizedTextService.Localize(FormsRteConstants.AeraName, FormsRteConstants.ErrorMessageKey), EventMessageType.Error));
                }
            }
        }
    }
}
