using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
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
        public object GetAllDocumentTypes(ElementFilter elementFilter = ElementFilter.All, TemplateFilter templateFilter = TemplateFilter.All, string filterTerm = "")
        {
            var retval = new List<object>();

            filterTerm = filterTerm ?? "";

            foreach( var doctype in Services.ContentTypeService.GetAll()
                .If(elementFilter == ElementFilter.Elements, q => q.Where(c => c.IsElement))
                .If(elementFilter == ElementFilter.Pages, q => q.Where(c => !c.IsElement))
                .If(templateFilter == TemplateFilter.HasTemplate, q => q.Where(c => c.AllowedTemplates.Any()))
                .If(templateFilter == TemplateFilter.NoTemplate, q => q.Where(c => !c.AllowedTemplates.Any()))
                .If(filterTerm != "", q => q.Where(c => c.Alias.Contains(filterTerm, StringComparison.OrdinalIgnoreCase)).OrderBy(d => d.Name)))
            {
                retval.Add(new { id = doctype.Id, alias = doctype.Alias, name = doctype.Name });
            }

            return retval;
        }

        public enum ElementFilter
        {
            All,
            Pages,
            Elements
        }

        public enum TemplateFilter
        {
            All,
            NoTemplate,
            HasTemplate
        }

    }
    public static class Extensions
        {
        public static IEnumerable<TSource> If<TSource>(
         this IEnumerable<TSource> source,
         bool condition,
         Func<IEnumerable<TSource>, IEnumerable<TSource>> branch)
        {
            return condition ? branch(source) : source;
        }
   
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}