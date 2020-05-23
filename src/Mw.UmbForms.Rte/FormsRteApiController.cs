using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Models.ContentEditing;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Mw.UmbForms.Rte
{
    [PluginController(FormsRteConstants.AeraName)]
    public class FormsRteApiController : UmbracoAuthorizedApiController
    {
        private readonly IDataTypeService _dataTypeService;

        public FormsRteApiController(IDataTypeService dataTypeService)
        {
            _dataTypeService = dataTypeService;
        }

        public DataTypeDisplay GetDataType()
        {
            var dataType = _dataTypeService.GetDataType(FormsRteConstants.DataTypeName);
            return dataType == null ? null : Mapper.Map<IDataType, DataTypeDisplay>(dataType);
        }
    }
}
