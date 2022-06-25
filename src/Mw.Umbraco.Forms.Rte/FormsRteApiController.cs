using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace Mw.Umbraco.Forms.Rte
{
    [PluginController(FormsRteConstants.AeraName)]
    public class FormsRteApiController : UmbracoAuthorizedApiController
    {
        private readonly IDataTypeService _dataTypeService;
        private readonly IUmbracoMapper _umbracoMapper;

        public FormsRteApiController(IDataTypeService dataTypeService, IUmbracoMapper umbracoMapper)
        {
            _dataTypeService = dataTypeService;
            _umbracoMapper = umbracoMapper;
        }

        public DataTypeDisplay GetDataType()
        {
            var dataType = _dataTypeService.GetDataType(FormsRteConstants.DataTypeName);
            return dataType == null ? null : _umbracoMapper.Map<IDataType, DataTypeDisplay>(dataType);
        }
    }
}
