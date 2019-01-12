using AutoMapper;
using Umbraco.Core.Models;
using Umbraco.Web.Models.ContentEditing;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Mw.UmbForms.Rte.Controllers
{
    [PluginController("FormsRte")]
    public class FormsRteApiController : UmbracoAuthorizedApiController
    {
        public DataTypeDisplay GetByName(string name)
        {
            var dataType = Services.DataTypeService.GetDataTypeDefinitionByName(name);
            return dataType == null ? null : Mapper.Map<IDataTypeDefinition, DataTypeDisplay>(dataType);
        }
    }
}
