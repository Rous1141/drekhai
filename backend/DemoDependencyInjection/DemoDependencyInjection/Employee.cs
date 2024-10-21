﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDependencyInjection
{
    //This is going to be our Model class which holds the Model data
    //This class is going to be used by both EmployeeDAL and EmployeeBL
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
