using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CustomerDAL;

namespace CustomerService.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		public IEnumerable<Customer> Get()
		{

			using (NORTHWNDEntities1 objDB =new NORTHWNDEntities1())
			{
				return objDB.Customers.ToList();
			}
		}

		// GET api/values/5
		public HttpResponseMessage Get(string id)
		{
			using (NORTHWNDEntities1 objDB = new NORTHWNDEntities1())
			{
				var cust = objDB.Customers.FirstOrDefault(e => e.CustomerID == id);
				if (cust != null)
					return Request.CreateResponse(HttpStatusCode.OK, cust);
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer Not Found");
			}
		}

		// POST api/values
		public HttpResponseMessage Post([FromBody]Customer customer)
		{
			try
			{ 
			using (NORTHWNDEntities1 objDB = new NORTHWNDEntities1())
			{
				objDB.Customers.Add(customer);
				objDB.SaveChanges();
				var message = Request.CreateResponse(HttpStatusCode.Created, customer);
				message.Headers.Location = new Uri(Request.RequestUri + customer.CustomerID);
				return message;
			}
			}
			catch(Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public HttpResponseMessage Delete(string id)
		{
			try
			{
				using (NORTHWNDEntities1 objDB = new NORTHWNDEntities1())
				{
					var cust = objDB.Customers.FirstOrDefault(e => e.CustomerID == id);
					if (cust != null)
					{
						objDB.Customers.Remove(cust);
						return Request.CreateResponse(HttpStatusCode.OK);
					}
					else
					{
						return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer Not Found");
					}
				}
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}
	}
}
