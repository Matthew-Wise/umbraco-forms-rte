using System;
using System.Collections.Generic;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;
using Umbraco.Web.PropertyEditors;

namespace Mw.UmbForms.Rte.Composing
{
    public class FormsRteComponent : IComponent
    {
        private readonly IDataTypeService _dataTypeService;

        private readonly PropertyEditorCollection _propertyEditorCollection;

        private readonly ILocalizedTextService _localizedTextService;

        public FormsRteComponent(IDataTypeService dataTypeService, PropertyEditorCollection propertyEditorCollection, ILocalizedTextService localizedTextService)
        {
            _dataTypeService = dataTypeService;
            _propertyEditorCollection = propertyEditorCollection;
            _localizedTextService = localizedTextService;
        }

        public void Initialize()
        {
            DataTypeService.Deleting += StopFormRteDelete;
            CreateRteDataType();          

        }
        
        public void Terminate()
        {
            // Nothing to terminate
        }

        private void CreateRteDataType()
        {
            if (_dataTypeService.GetDataType(FormsRteConstants.DataTypeName) != null || !_propertyEditorCollection.TryGet(Constants.PropertyEditors.Aliases.TinyMce, out var editor))
            {
                return;
            }

            var formsRte = new DataType(editor)
            {
                Name = FormsRteConstants.DataTypeName,
                Configuration = new RichTextConfiguration
                {
                    Editor = Newtonsoft.Json.Linq.JObject.FromObject(new Dictionary<string, object>
                    {
                        ["toolbar"] = new[] { "ace", "bold", "italic", "bullist", "numlist", "link", "umbmediapicker" },
                        ["stylesheets"] = Array.Empty<string>(),
                        ["maxImageSize"] = 500,
                        ["mode"] = "classic"
                    }),
                    HideLabel = false,
                    IgnoreUserStartNodes = false,
                    MediaParentId = null
                }
            };

            _dataTypeService.Save(formsRte);
        }

        private void StopFormRteDelete(IDataTypeService dataTypeService, DeleteEventArgs<IDataType> e)
        {
            foreach (var dt in e.DeletedEntities)
            {
                if (dt.Name == FormsRteConstants.DataTypeName && e.CanCancel)
                {
                    e.CancelOperation(new EventMessage("Error", _localizedTextService.Localize(FormsRteConstants.AeraName, FormsRteConstants.ErrorMessageKey), EventMessageType.Error));
                }
            }
        }       
    }
}
