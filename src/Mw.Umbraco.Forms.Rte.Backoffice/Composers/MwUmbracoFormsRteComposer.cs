using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Mw.Umbraco.Forms.Rte.Backoffice.Composers
{
    public class MwUmbracoFormsRteComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.ManifestFilters().Append<MwUmbracoFormsRteManifestFilter>();
        }
    }
}
