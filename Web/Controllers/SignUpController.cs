
using System.Linq;
using System.Web.Http;
using Umbraco.Core.Services;
using Umbraco.Web.PublishedModels;
using Umbraco.Web.WebApi;
using Web.Models;

namespace Web.Controllers
{
    public class SignUpController : UmbracoApiController
    {
        [HttpPost]
        public IHttpActionResult CreateVolunteer(VolunteerDTO volunteer)
        {
            var rootNode = Umbraco.ContentAtRoot().OfType<RegisteredPeople>().FirstOrDefault();

            var content = Services.ContentService.Create(volunteer.PersonName, rootNode.Id, Volunteer.ModelTypeAlias);
            content.SetValue(Volunteer.GetModelPropertyType(x => x.PersonName).Alias, volunteer.PersonName);
            content.SetValue(Volunteer.GetModelPropertyType(x => x.Phone).Alias, volunteer.Phone);
            content.SetValue(Volunteer.GetModelPropertyType(x => x.Age).Alias, volunteer.Age);
            content.SetValue(Volunteer.GetModelPropertyType(x => x.HomeAddress).Alias, volunteer.HomeAddress);
            content.SetValue(Volunteer.GetModelPropertyType(x => x.Description).Alias, volunteer.Description);
            content.SetValue(Volunteer.GetModelPropertyType(x => x.Type).Alias, "Volunteer");

            var result = Services.ContentService.Save(content);

            return HandleContentSave(result);

        }

        [HttpPost]
        public IHttpActionResult CreateBenefactor(BenefactorDTO benefactor)
        {
            var rootNode = Umbraco.ContentAtRoot().OfType<RegisteredPeople>().FirstOrDefault();

            var content = Services.ContentService.Create(benefactor.PersonName, rootNode.Id, Benefactor.ModelTypeAlias);
            content.SetValue(Benefactor.GetModelPropertyType(x => x.PersonName).Alias, benefactor.PersonName);
            content.SetValue(Benefactor.GetModelPropertyType(x => x.Phone).Alias, benefactor.Phone);
            content.SetValue(Benefactor.GetModelPropertyType(x => x.Email).Alias, benefactor.Email);
            content.SetValue(Benefactor.GetModelPropertyType(x => x.Description).Alias, benefactor.Description);
            content.SetValue(Benefactor.GetModelPropertyType(x => x.Type).Alias, "Benefactor");

            var result = Services.ContentService.Save(content);

            return HandleContentSave(result);
        }

        [HttpPost]
        public IHttpActionResult CreateSupplier(SupplierDTO supplier)
        {
            var rootNode = Umbraco.ContentAtRoot().OfType<RegisteredPeople>().FirstOrDefault();

            var content = Services.ContentService.Create(supplier.PersonName, rootNode.Id, Supplier.ModelTypeAlias);
            content.SetValue(Supplier.GetModelPropertyType(x => x.PersonName).Alias, supplier.PersonName);
            content.SetValue(Supplier.GetModelPropertyType(x => x.Phone).Alias, supplier.Phone);
            content.SetValue(Supplier.GetModelPropertyType(x => x.Email).Alias, supplier.Email);
            content.SetValue(Supplier.GetModelPropertyType(x => x.Description).Alias, supplier.Description);
            content.SetValue(Supplier.GetModelPropertyType(x => x.Type).Alias, "Supplier");

            var result = Services.ContentService.Save(content);

            return HandleContentSave(result);
        }

        [HttpPost]
        public IHttpActionResult CreateExtraDoctor(ExtraDoctorDTO extraDoctor)
        {
            var rootNode = Umbraco.ContentAtRoot().OfType<RegisteredPeople>().FirstOrDefault();

            var content = Services.ContentService.Create(extraDoctor.PersonName, rootNode.Id, ExtraDoctor.ModelTypeAlias);
            content.SetValue(ExtraDoctor.GetModelPropertyType(x => x.PersonName).Alias, extraDoctor.PersonName);
            content.SetValue(ExtraDoctor.GetModelPropertyType(x => x.Phone).Alias, extraDoctor.Phone);
            content.SetValue(ExtraDoctor.GetModelPropertyType(x => x.Age).Alias, extraDoctor.Age);
            content.SetValue(ExtraDoctor.GetModelPropertyType(x => x.Address).Alias, extraDoctor.HomeAddress);
            content.SetValue(ExtraDoctor.GetModelPropertyType(x => x.MedicalSpecialization).Alias, extraDoctor.Description);
            content.SetValue(ExtraDoctor.GetModelPropertyType(x => x.Type).Alias, "ExtraDoctor");

            var result = Services.ContentService.Save(content);
            
            return HandleContentSave(result);
        }

        private IHttpActionResult HandleContentSave(OperationResult result)
        {
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}