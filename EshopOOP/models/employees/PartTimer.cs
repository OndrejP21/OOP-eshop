using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models.employees
{
    public class PartTimer : Employee
    {
        public ushort MoneyForHour { get; private set; }
        public ushort Hours { get; private set; }

        public PartTimer(int id, EmployeeType employeeType, string name, Department department, DateTime startDate, float workload,
            ushort moneyForHour, ushort hours) : base(id, employeeType, name, department, startDate, null, workload)
        {
            MoneyForHour = moneyForHour;
            Hours = hours;
        }

        public PartTimer(int id, EmployeeType employeeType, string name, Department department, float workload, 
            ushort moneyForHour, ushort hours) : this(id, employeeType, name, department, DateTime.Now, workload, moneyForHour, hours)
        {
        }
    }
}
