using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CashFlow.Controllers
{
    public class TransactionContextController : ApiBaseController
    {
        // GET api/<controller>
        public IEnumerable<Transaction> Get()
        {
            throw new UnauthorizedAccessException();
        }

        // GET api/<controller>/5
        public Transaction Get(int id)
        {
            throw new UnauthorizedAccessException();
        }

        // POST api/<controller>
        public void Post([FromBody]Transaction value)
        {
            throw new UnauthorizedAccessException();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Transaction value)
        {
            throw new UnauthorizedAccessException();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new UnauthorizedAccessException();
        }
    }
}