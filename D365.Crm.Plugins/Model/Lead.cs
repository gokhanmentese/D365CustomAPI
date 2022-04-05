using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace D365.CustomApi.Model
{
    public class Lead
    {
        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "LastName")]
        public string LastName { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Company")]
        public string Company { get; set; }

        [DataMember(Name = "LeadSource")]
        public string LeadSource { get; set; }

        [DataMember(Name = "Status")]
        public string Status { get; set; }

        [DataMember(Name = "Street")]
        public string Street { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "State")]
        public string State { get; set; }

        [DataMember(Name = "PostalCode")]
        public string PostalCode { get; set; }

        [DataMember(Name = "Phone")]
        public string Phone { get; set; }

        [DataMember(Name = "Subject")]
        public string Subject { get; set; }
    }
}
