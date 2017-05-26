using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using UserAwards.Models;
using Microsoft.Data.OData;

namespace UserAwards.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using UserAwards.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<PersonModel>("PersonModelsApi");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PersonModelsApiController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/PersonModelsApi
        public IHttpActionResult GetPersonModelsApi(ODataQueryOptions<PersonModel> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<PersonModel>>(personModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/PersonModelsApi(5)
        public IHttpActionResult GetPersonModel([FromODataUri] System.Guid key, ODataQueryOptions<PersonModel> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<PersonModel>(personModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/PersonModelsApi(5)
        public IHttpActionResult Put([FromODataUri] System.Guid key, Delta<PersonModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(personModel);

            // TODO: Save the patched entity.

            // return Updated(personModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/PersonModelsApi
        public IHttpActionResult Post(PersonModel personModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(personModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/PersonModelsApi(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] System.Guid key, Delta<PersonModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(personModel);

            // TODO: Save the patched entity.

            // return Updated(personModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/PersonModelsApi(5)
        public IHttpActionResult Delete([FromODataUri] System.Guid key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
