using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using FBConsultTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FBConsultTest.Controllers
{
    public class ContactController : ApiController
    {
        private IContactService _service;
        private IMapper _mapper;
        public ContactController(IContactService service)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactDTO>();
                cfg.CreateMap<ContactDTO, Contact>();
            });
            _mapper = config.CreateMapper();

            _service = service;
        }
        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Get()
        {
            var contacts = _mapper.Map<ICollection<ContactDTO>, ICollection<Contact>>(_service.GetAll());

            if (contacts == null)
            {
                return NotFound();
            }
            return Ok(contacts);

        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var contact = _mapper.Map<ContactDTO, Contact>(_service.Find(id));

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody] Contact item)
        {
            try
            {
                _service.Add(_mapper.Map<Contact, ContactDTO>(item));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] Contact item)
        {
            try
            {
                _service.Update(_mapper.Map<Contact, ContactDTO>(item));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}