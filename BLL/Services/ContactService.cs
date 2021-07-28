using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ContactService : BaseService<ContactDTO, Contact>
    {
        public ContactService(IBaseRepository<Contact> repository) : base(repository)
        {
        }
    }
}
