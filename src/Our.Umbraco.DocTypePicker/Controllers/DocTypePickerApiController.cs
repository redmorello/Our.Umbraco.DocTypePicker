using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.DocTypePicker.Controllers
{
    /// <summary>
    /// Umbraco API Controller for the Document Type Picker data type.
    /// </summary>
    [PluginController("OurUmbracoDocTypePicker")]
    public class DocTypePickerApiController : UmbracoAuthorizedJsonController
    {
        /// <summary>
        /// Get method to retrieve a list of all document types.
        /// </summary>
        /// <returns>A sorted list of all document types.</returns>
        public object GetAllDocumentTypes()
        {
            var retval = new List<Object>();

            foreach (var doctype in Services.ContentTypeService.GetAllContentTypes().OrderBy(d => d.Name))
                retval.Add(new { id = doctype.Id, alias = doctype.Alias, name = doctype.Name });

            return retval;
        }
    }
}