using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaniaDriveMobile.Models
{
    class Payment
    {
        public virtual int PaymentId { get; set; }
        public virtual string BankName { get; set; }
        //  public virtual int TaskId { get; set; }
    }
}
