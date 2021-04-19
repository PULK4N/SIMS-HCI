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
    public Employee()
    {
    }

    public Employee(/*long employeeId, */float salary, DateTime beginWorkingHours, DateTime endWorkingHours, int annualLeave, int sickLeave, User user)
    {
    //    EmployeeId = employeeId;
        Salary = salary;
        BeginWorkingHours = beginWorkingHours;
        EndWorkingHours = endWorkingHours;
        AnnualLeave = annualLeave;
        SickLeave = sickLeave;
        User = user;
    }



    [Key]
    public long EmployeeId { get; set; }
    public float Salary { get; set; }
    public DateTime BeginWorkingHours { get; set; }
    public DateTime EndWorkingHours { get; set; }
    public int AnnualLeave { get; set; }
    public int SickLeave { get; set; }
    [Required, Index("uniqueUserEmp", IsUnique = true)]
    public User User { get; set; }

}