﻿using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;

namespace DaniaDriveMetro.Model
{
    public class Payment
    {
        public virtual int PaymentId { get; set; }
        public virtual string BankName { get; set; }
      //  public virtual int TaskId { get; set; }
    }
}