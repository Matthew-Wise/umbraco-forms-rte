using Mw.Umbraco.Forms.Rte.Extensions;
using Mw.Umbraco.Forms.Rte.NotificationHandlers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Mw.Umbraco.Forms.Rte.Composing;

public class FormsRteComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddComponent<FormsRteComponent>();
        builder.AddNotificationHandler<DataTypeDeletingNotification, StopFormRteDeleteNotificationHandler>();
        builder.AddFormsRteField();
    }
}