<<<<<<< HEAD
﻿using MySqlX.XDevAPI.Relational;
using System;
=======
﻿using System;
>>>>>>> ffac5bf8acbeee7fa07991c6cfa003738767045d
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApplication1
{
    public class UserDetails
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string MaritalStatus { get; set; }
        public string CountryStatus { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public double CurrentBalance { get; set; }
        public string Email { get; set; }
        public int SinNumber { get; set; }
<<<<<<< HEAD
        public double ChequingAccountBalance { get; set; }
        public double SavingAccountBalance { get; set; }
        public double LoanAccountBalance { get; set; }
=======
>>>>>>> ffac5bf8acbeee7fa07991c6cfa003738767045d
    }
}