using Microsoft.Extensions.Configuration;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Forms.Core.Providers;

namespace Mw.Umbraco.Forms.Rte.Extensions
{
    public static class UmbracoBuilderExtensions
    {
        public static IUmbracoBuilder AddFormsRteField(this IUmbracoBuilder builder)
        {
            builder.WithCollectionBuilder<FieldCollectionBuilder>().Add<FormsRteFieldType>();
            return builder;
        }
    }
}
