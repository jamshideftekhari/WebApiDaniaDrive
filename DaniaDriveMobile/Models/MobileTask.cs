using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaniaDriveMobile.Models
{
    class MobileTask
    {
        public virtual int MobileTaskId { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual int PaymentId { get; set; }
        public virtual int Milage { get; set; }
        public virtual int ElapsedTime { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
