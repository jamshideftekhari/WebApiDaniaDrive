using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDaniaDrive.Models
{
    public class DaniaTask
    {
        public virtual int DaniaTaskId { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual int PaymentId { get; set; }
        public virtual int Milage { get; set; }
        public virtual int ElapsedTime { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Payment Payment { get; set; }
    }
}