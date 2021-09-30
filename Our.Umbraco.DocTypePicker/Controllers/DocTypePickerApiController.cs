using System;
using System.Collections.Generic;
using System.Linq;

#if NETCOREAPP
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;
#else
using Umbraco.Core.Services;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;
#endif

namespace Our.Umbraco.DocTypePicker.Controllers
{
    /// <summary>
    /// Umbraco API Controller for the Document Type Picker data type.
    /// </summary>
    [PluginController("OurUmbracoDocTypePicker")]
    public class DocTypePickerApiController : UmbracoAuthorizedJsonController
    {
        private readonly IContentTypeService _contentTypeService;

        public DocTypePickerApiController(IContentTypeService contentTypeService)
        {
            _contentTypeService = contentTypeService;
        }

        /// <summary>
        /// Get method to retrieve a list of all document types.
        /// </summary>
        /// <returns>A sorted list of all document types.</returns>
        public object GetAllDocumentTypes()
        {
            var retval = new List<Object>();

            foreach (var doctype in _contentTypeService.GetAll().OrderBy(d => d.Name))
                retval.Add(new { id = doctype.Id, alias = doctype.Alias, name = doctype.Name });

            return retval;
        }
    }
}