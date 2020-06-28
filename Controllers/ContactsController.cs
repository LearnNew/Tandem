using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tandem.Models;

namespace Tandem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // GET: api/Contacts
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            throw new NotImplementedException();
        }

    }
}
