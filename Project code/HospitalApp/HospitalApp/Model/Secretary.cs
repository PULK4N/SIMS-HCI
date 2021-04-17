/***********************************************************************
 * Module:  Secretary.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class Secretary
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Secretary
{
    [Key]
    public long SecretaryId{ get; set; }

    [Required, Index("uniqueEmpSec", IsUnique = true)]
    public Employee Employee{ get; set; }

}