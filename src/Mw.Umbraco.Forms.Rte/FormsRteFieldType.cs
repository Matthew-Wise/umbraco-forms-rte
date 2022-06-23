using System;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Attributes;
using Umbraco.Forms.Core.Enums;

namespace Mw.Umbraco.Forms.Rte
{
    public sealed class FormsRteFieldType : FieldType
    {
        public FormsRteFieldType()
        {
            Name = "Rich Text";
            Icon = "icon-code";
            Description = "Rich text to display";
            Id = new Guid("826e9dca-91bc-4672-945c-f110c8121f60");
            DataType = FieldDataType.LongString;
            SortOrder = 100;
            FieldTypeViewName = "FieldType.RichText.cshtml";
        }

        [Setting("Html", Description = "Rich text to display", View = "~/App_Plugins/Mw.Umbraco.Forms.Rte/editor.html")]
        public string Html { get; set; }

        public override bool HideLabel => true;

        public override bool StoresData => false;

        public override string GetDesignView() => "~/App_Plugins/Mw.Umbraco.Forms.Rte/design.html";
    }
}
