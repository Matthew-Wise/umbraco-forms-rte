using System.Collections.Generic;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace Mw.UmbForms.Rte.Composing
{
    public class FormsRteComponent : IComponent
    {
        private const string FormRteName = "Form RTE";

        private readonly IDataTypeService _dataTypeService;
        private readonly PropertyEditorCollection _propertyEditorCollection;

        public FormsRteComponent(IDataTypeService dataTypeService, PropertyEditorCollection propertyEditorCollection)
        {
            _dataTypeService = dataTypeService;
            _propertyEditorCollection = propertyEditorCollection;
        }

        public void Initialize()
        {
            DataTypeService.Deleting += StopFormRteDelete;

            if (_dataTypeService.GetDataType(FormRteName) != null || !_propertyEditorCollection.TryGet(Constants.PropertyEditors.Aliases.TinyMce, out var editor)) return;

            var formsRTE = new DataType(editor)
            {
                Name = FormRteName,
                Configuration = new Dictionary<string, object>
                {
                    ["editor"] = new Dictionary<string, object>
                    {
                        ["toolbar"] = new[] { "ace", "bold", "italic", "bullist", "numlist", "link", "umbmediapicker" },
                        ["stylesheets"] = new string[0],
                        ["maxImageSize"] = 500,
                        ["mode"] = "classic"
                    },
                    ["hideLabel"] = false,
                    ["ignoreUserStartNodes"] = false,
                    ["mediaParentId"] = null
                }
            };

            _dataTypeService.Save(formsRTE);
        }


        private void StopFormRteDelete(IDataTypeService sender, DeleteEventArgs<IDataType> e)
        {
            foreach (var dt in e.DeletedEntities)
            {
                if (dt.Name == FormRteName && e.CanCancel)
                {
                    e.CancelOperation(new EventMessage("Error", "This data type is used by Umbraco Forms Rich Text field", EventMessageType.Error));
                }
            }
        }

        public void Terminate()
        {
        }
    }
}
