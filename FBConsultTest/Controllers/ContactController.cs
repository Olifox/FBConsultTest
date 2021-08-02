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
        private IBaseService<ContactDTO> _service;
        private IMapper _mapper;
        public ContactController(IBaseService<ContactDTO> service)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactDTO>();
                cfg.CreateMap<ContactDTO, Contact>();
                cfg.CreateMap<ContactDTO, ContactFullName>()
                    .ForMember("FullName", opt => opt.MapFrom(c => string.Format("{0} {1} {2}", c.Surname, c.Name, c.Patronymic)));
            });
            _mapper = config.CreateMapper();

            _service = service;
        }
        // GET api/<controller>
        [Route("GetFullName")]
        [HttpGet]
        public IHttpActionResult GetFullName()
        {
            var contacts = _mapper.Map<ICollection<ContactDTO>, ICollection<ContactFullName>>(_service.GetAll());

            if (contacts == null)
            {
                return NotFound();
            }
            return Ok(contacts);

        }

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
        public IHttpActionResult Post(Contact item)
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