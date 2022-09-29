using Module3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Module3_MVC.API
{
    public class PeopleController : ApiController
    {
        // GET: api/People
        public People Get()
        {
            List<Person>_personList = new List<Person>();
            // This would come from  a data source or data provider!!
            _personList.Add(new Person("Doe", "Jane", new DateTime(1971, 7, 1)));
            _personList.Add(new Person("Patel", "Anna", new DateTime(1975, 2, 10)));
            People _people = new People(_personList.ToArray());
            return _people;
        }

        // GET: api/People/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/People
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
