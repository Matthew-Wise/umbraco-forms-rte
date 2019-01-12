using System.Collections.Generic;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace Mw.UmbForms.Rte
{
    public class FormsRteCreator : IApplicationEventHandler
    {
        private string FormRteName = "Form RTE";

        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            if (!applicationContext.IsConfigured) return;
            DataTypeService.Deleting += StopFormRteDelete;
            var dataTypeService = applicationContext.Services.DataTypeService;

            if (dataTypeService.GetDataTypeDefinitionByName(FormRteName) != null) return;

            var formsRTE = new DataTypeDefinition(Constants.PropertyEditors.TinyMCEAlias)
            {
                Name = FormRteName
            };
            var prevalues = new Dictionary<string, PreValue>
            {
                { "editor", new PreValue(
                @"{
                    toolbar: [""code"", ""bold"", ""italic"", ""bullist"", ""numlist"", ""link"", ""umbmediapicker""],
                    stylesheets: [],
                    dimensions: { height: 500 },
                    maxImageSize: 500
                }") }
            };
            dataTypeService.SaveDataTypeAndPreValues(formsRTE, prevalues);
        }


        private void StopFormRteDelete(IDataTypeService sender, DeleteEventArgs<IDataTypeDefinition> e)
        {
            foreach (var dt in e.DeletedEntities)
            {
                if (dt.Name == FormRteName && e.CanCancel)
                {
                    e.CancelOperation(new EventMessage("Error", "This data type is used by Umbraco Forms Rich Text field", EventMessageType.Error));
                }
            }
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }
    }
}
