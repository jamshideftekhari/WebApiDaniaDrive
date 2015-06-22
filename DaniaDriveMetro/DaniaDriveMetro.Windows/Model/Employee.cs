using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;

namespace DaniaDriveMetro.Model
{
    public class Employee
    {
        public virtual int EmployId { get; set; }
        public virtual string EmployeeName { get; set; }
        public virtual string EmployeeLastName { get; set; }
        public virtual string PhoneNr { get; set; }
        public virtual string EMail { get; set; }
        public virtual string Picture { get; set; }
        public virtual string AccountNr { get; set; }
    }
}