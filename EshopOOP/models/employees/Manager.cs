using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models.employees
{
    public class Manager : Employee
    {
        public uint Bonus { get; private set; }
        public byte Subordinates { get; private set; } // počet podřízených
        public TrueFactor HasCar { get; private set;  }

        public Manager(int id, EmployeeType employeeType, string name, Department department, DateTime startDate,
            uint? salary, float workload, uint bonus, byte subordinates, TrueFactor hasCar) : 
            base(id, employeeType, name, department, startDate, salary, workload)
        {
            Bonus = bonus;
            Subordinates = subordinates;
            HasCar = hasCar;
        }

        public Manager(int id, EmployeeType employeeType, string name, Department department, float workload, 
            uint bonus, byte subordinates, TrueFactor hasCar) : 
            this(id, employeeType, name, department, DateTime.Now, workload, bonus, subordinates, hasCar)
        {
        }

        public Manager(int id, EmployeeType employeeType, string name, Department department, DateTime startDate, float workload,
            uint bonus, byte subordinates, TrueFactor hasCar) : 
            this(id, employeeType, name, department, startDate, null, workload, bonus, subordinates, hasCar)
        {
        }

        public Manager(int id, EmployeeType employeeType, string name, Department department, 
            uint salary, float workload, uint bonus, byte subordinates, TrueFactor hasCar) : 
            this(id, employeeType, name, department, DateTime.Now, salary, workload, bonus, subordinates, hasCar)
        {
        }
    }
}
