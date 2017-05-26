using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.Routing;
using UserAwards.Models;
using UserAwards.Models.Helpers;

namespace UserAwards.Controllers
{
	public class PersonApiController : ApiController
	{
		// GET: api/PersonApi
		public IEnumerable<string> Get()
		{
			return new string[] {"value1", "value2"};
		}


		[System.Web.Http.Route("api/users")]
		public IEnumerable<PersonModel> GetPersons()
		{
			return PersonHelper.PersonModelList.ToList();
		}

		[System.Web.Http.Route("api/users/{letter:maxlength(1)}")]
		public IEnumerable<PersonModel> GetPersonsByLetter(string letter)
		{
			return PersonHelper.PersonModelList.Where(_=>_.Name.StartsWith(letter)).ToList();
		}

		[System.Web.Http.Route("api/users/{name}")]
		public IEnumerable<PersonModel> GetPersonsByName(string name)
		{
			return PersonHelper.PersonModelList.Where(_ => _.Name == name).OrderBy(_=>_.Age).Take(1);
		}

		[System.Web.Http.Route("api/user)")]
		public HttpResponseMessage CreateNewPerson()
		{
			return Request.CreateResponse(HttpStatusCode.OK, new { content = "" });
		}

		[System.Web.Http.Route("api/user/{name}")]
		public IEnumerable<PersonModel> GetPersonByName(string name)
		{
			return PersonHelper.PersonModelList.Where(_ => _.Name == name).OrderBy(_ => _.Age).Take(1); ;
		}

		[System.Web.Http.Route("api/user/{id:guid}")]
		public IEnumerable<PersonModel> GetPersonById(Guid id)
		{
			return PersonHelper.PersonModelList.Where(_ => _.Id == id).ToList();
		}
	

		
		// GET: api/PersonApi/5
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/PersonApi
		public void Post(PersonModel model)
		{
			PersonHelper.CreateEntity(model);
		}

		// PUT: api/PersonApi/5
		public void Put(PersonModel model)
		{
			PersonHelper.UpdateEntity(model);
		}

		// DELETE: api/PersonApi/5
		public void Delete(Guid id)
		{
			PersonHelper.DeleteEntity(id);
		}
	}
}

