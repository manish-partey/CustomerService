using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
		public Customer Get(string id)
		{
			using (NORTHWNDEntities1 objDB = new NORTHWNDEntities1())
			{
				return objDB.Customers.FirstOrDefault(e => e.CustomerID == id);
			}
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
