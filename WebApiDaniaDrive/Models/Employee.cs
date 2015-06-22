using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDaniaDrive.Models
{
    public class Employee
    {
        public virtual int EmployeeId { get; set; }
        public virtual string EmployeeName { get; set; }
        public virtual string EmployeeLastName { get; set; }
        public virtual string PhoneNr { get; set; }
        public virtual string EMail { get; set; }
        public virtual string Picture { get; set; }
        public virtual string AccountNr { get; set; }
    }
}