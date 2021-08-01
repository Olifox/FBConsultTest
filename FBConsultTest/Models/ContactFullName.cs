using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBConsultTest.Models
{
    public class ContactFullName
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public DateTime? Bithday { get; set; }
    }
}