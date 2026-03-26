using EshopOOP.models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopOOP.models
{
    public class Employee
    {
        public int Id { get; private set; }
        public EmployeeType EmployeeType { get; private set; }
        public string Name { get; private set; }
        public Department Department { get; private set; }
        public DateTime StartDate { get; private set; }
        public uint? Salary { get; private set; } = null;
        public float Workload { get; private set; }

        public Employee(int id, EmployeeType employeeType, string name, Department department, DateTime startDate, 
            uint? salary, float workload)
        {
            Id = id;
            EmployeeType = employeeType;
            Name = name;
            Department = department;
            StartDate = startDate;
            Salary = salary;
            Workload = workload;
        }

        public Employee(int id, EmployeeType employeeType, string name, Department department, DateTime startDate,
            float workload) : this(id, employeeType, name, department, startDate, null, workload)
        {
        }

        public Employee(int id, EmployeeType employeeType, string name, Department department, uint salary, float workload) : 
            this(id, employeeType, name, department, DateTime.Now, salary, workload)
        {
        }
        public Employee(int id, EmployeeType employeeType, string name, Department department, float workload) :
            this(id, employeeType, name, department, DateTime.Now, null, workload)
        {
        }
    }
}
