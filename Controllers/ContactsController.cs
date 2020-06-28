using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tandem.Interfaces;
using Tandem.Models;

namespace Tandem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsDbService _contactsDbService;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactsController> _logger;


        public ContactsController(IContactsDbService contactsDbService, IMapper mapper, ILogger<ContactsController> logger)
        {
            _contactsDbService = contactsDbService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return (await _contactsDbService.GetContactsAsync(@"Select * From Contacts"));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateAsync(PostContact postContact)
        {
            var contact = _mapper.Map<Contact>(postContact);

            //create new partition key
            contact.Id = Guid.NewGuid().ToString();

            try
            {
                await _contactsDbService.AddContactAsync(contact);
            }
            catch(Exception ex)
            {
                var message = string.Format(@"Could not create contact for user {0} Exception {1}", 
                    postContact.EmailAddress,
                    ex.Message);

                _logger.LogWarning(message);
                throw new ApplicationException(@"Could not create contact"); 
            }
            return CreatedAtAction(nameof(Get), null, null);
        }
    }
}
