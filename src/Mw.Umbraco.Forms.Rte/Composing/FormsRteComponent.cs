using System;
using System.Collections.Generic;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Serialization;
using Umbraco.Cms.Core.Services;

namespace Mw.Umbraco.Forms.Rte.Composing
{
    public class FormsRteComponent : IComponent
    {
        private readonly IDataTypeService _dataTypeService;
        private readonly IConfigurationEditorJsonSerializer _configurationEditorJsonSerializer;
        private readonly PropertyEditorCollection _propertyEditorCollection;

        public FormsRteComponent(IDataTypeService dataTypeService, PropertyEditorCollection propertyEditorCollection, IConfigurationEditorJsonSerializer configurationEditorJsonSerializer)
        {
            _dataTypeService = dataTypeService;
            _propertyEditorCollection = propertyEditorCollection;
            _configurationEditorJsonSerializer = configurationEditorJsonSerializer;
        }

        public void Initialize()
        {
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

            var formsRte = new DataType(editor, _configurationEditorJsonSerializer)
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
    }
}
