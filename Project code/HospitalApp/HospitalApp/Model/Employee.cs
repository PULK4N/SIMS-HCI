/***********************************************************************
 * Module:  Employee.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class Employee
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    public long EmployeeId { get; set; }
    public float Salary { get; set; }
    public uint WorkingHours { get; set; }
    public int AnnualLeave { get; set; }
    public int SickLeave { get; set; }
    [Required, Index("uniqueUserEmp", IsUnique = true)]
    public User User { get; set; }

}