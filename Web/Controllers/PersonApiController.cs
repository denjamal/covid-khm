
using System.Linq;
using System.Web.Http;
using System.Web.Http;
using Umbraco.Web.PublishedModels;
using Umbraco.Web.WebApi;

namespace Web.Controllers
{
    public class PersonApiController : UmbracoApiController
    {
        [HttpPost]
        public IHttpActionResult Create()
        {
            var rootNode = Umbraco.ContentAtRoot().OfType<People>().FirstOrDefault();

            var content = Services.ContentService.Create("Person1", rootNode.Id, Supplier.ModelTypeAlias);
            content.SetValue(Supplier.GetModelPropertyType(x => x.PersoneName).Alias, "Created from code");
            content.SetValue(Supplier.GetModelPropertyType(x => x.Phone).Alias, "80979219600");
            content.SetValue(Supplier.GetModelPropertyType(x => x.Message).Alias, "80979219600");

            var result = Services.ContentService.Save(content);
            return Ok();
        }
    }
}