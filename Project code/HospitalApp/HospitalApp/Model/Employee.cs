/***********************************************************************
 * Module:  Employee.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class Employee
 ***********************************************************************/

using System;

public class Employee
{
    public long EmployeeId { get; set; }
    public float Salary { get; set; }
    public uint WorkingHours { get; set; }
    public int AnnualLeave { get; set; }
    public int SickLeave { get; set; }

    public User User { get; set; }

}