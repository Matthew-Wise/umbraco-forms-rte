using System;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;

namespace Mw.UmbForms.Rte.FieldTypes
{
    public class RichText : FieldType
    {
        public RichText()
        {
            Name = "Rich Text";
            Icon = "icon-code";
            Description = "Rich text to display";
            Id = new Guid("826e9dca-91bc-4672-945c-f110c8121f60");
            DataType = FieldDataType.LongString;
            SortOrder = 100;
            FieldTypeViewName = "FieldType.RichText.cshtml";
        }

        [Umbraco.Forms.Core.Attributes.Setting("Html", Description = "Rich text to display", 
            View = "~/App_Plugins/Mw.UmbForms.Rte/editor.html")]
        public string Html { get; set; }



        public override bool HideLabel
        {
            get
            {
                return true;
            }
        }

        public override bool StoresData
        {
            get
            {
                return false;
            }
        }

        public override string GetDesignView()
        {
            return "~/App_Plugins/Mw.UmbForms.Rte/design.html";
        }
    }
}
