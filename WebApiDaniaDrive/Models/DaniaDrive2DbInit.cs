using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDaniaDrive.Models
{
    public class DaniaDrive2DbInit : System.Data.Entity.DropCreateDatabaseAlways<WebApiDaniaDriveDbContext>
    {
        protected override void Seed(WebApiDaniaDriveDbContext context)
        {
            context.Employees.Add(new Employee { AccountNr = "12345678", EmployeeName = "Jamshid", EMail = "Jamshid@gmail.com", PhoneNr = "444888", EmployeeLastName = "Jami", Picture = "http://localhost:52921/images/pic1.jpg" });
            context.Employees.Add(new Employee { AccountNr = "99999999", EmployeeName = "Petri", EMail = "Petri@gmail.com", PhoneNr = "555888", EmployeeLastName = "Mikhal", Picture = "http://localhost:52921/images/pic1.jpg" });
            context.Payments.Add(new Payment {BankName = "DanskBank"});
            context.Payments.Add(new Payment { BankName = "Nordea" });
            context.Payments.Add(new Payment { BankName = "Saxo" });

            context.DaniaTasks.Add(new DaniaTask
            {
                Employee = new Employee { EmployeeName = "Anders", AccountNr = "98765432", EMail = "Anders@gmail.com", PhoneNr = "999888", EmployeeLastName = "Andersen", Picture = "http://localhost:52921/images/pic1.jpg" },
                Payment = new Payment{BankName = "Danskebank"},
                ElapsedTime = 60,
                DaniaTaskId = 1002,
                Milage = 45
            });
            context.DaniaTasks.Add(new DaniaTask
            {
                Employee = new Employee { EmployeeName = "Claus", AccountNr = "12345678", EMail = "Claus@gmail.com", PhoneNr = "199888", EmployeeLastName = "claussen", Picture = "http://localhost:52921/images/pic2.jpg" },
                Payment = new Payment { BankName = "Nordea" },
                ElapsedTime = 40,
                DaniaTaskId = 1003,
                Milage = 35
            });
            context.DaniaTasks.Add(new DaniaTask
            {
                Employee = new Employee { EmployeeName = "Hans", AccountNr = "67854322", EMail = "Hans@gmail.com", PhoneNr = "299888", EmployeeLastName = "hanssen", Picture = "http://localhost:52921/images/pic3.jpg" },
                Payment = new Payment { BankName = "Danskebank" },
                ElapsedTime = 80,
                DaniaTaskId = 1004,
                Milage = 65
            });

            context.DaniaTasks.Add(new DaniaTask
            {
                Employee = new Employee { EmployeeName = "Peter", AccountNr = "67854322", EMail = "peter@gmail.com", PhoneNr = "299888", EmployeeLastName = "Petersen", Picture = "http://localhost:52921/images/pic4.jpg" },
                Payment = new Payment { BankName = "Danskebank" },
                ElapsedTime = 80,
                DaniaTaskId = 1004,
                Milage = 65
            });
            context.DaniaTasks.Add(new DaniaTask
            {
                Employee = new Employee { EmployeeName = "poul", AccountNr = "67854322", EMail = "poul@gmail.com", PhoneNr = "299888", EmployeeLastName = "Poulsen", Picture = "http://localhost:52921/images/pic5.jpg" },
                Payment = new Payment { BankName = "Danskebank" },
                ElapsedTime = 80,
                DaniaTaskId = 1004,
                Milage = 65
            });
            context.DaniaTasks.Add(new DaniaTask
            {
                Employee = new Employee { EmployeeName = "Lars", AccountNr = "67854322", EMail = "Lars@gmail.com", PhoneNr = "299888", EmployeeLastName = "Larsensen", Picture = "http://localhost:52921/images/pic6.jpg" },
                Payment = new Payment { BankName = "Danskebank" },
                ElapsedTime = 80,
                DaniaTaskId = 1004,
                Milage = 65
            });


            base.Seed(context);
        }
    }
}