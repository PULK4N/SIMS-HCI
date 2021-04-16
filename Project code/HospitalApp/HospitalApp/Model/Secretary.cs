/***********************************************************************
 * Module:  Secretary.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class Secretary
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;

public class Secretary
{
    [Key]
    public long SecretaryId{ get; set; }

    [Required]
    public Employee Employee{ get; set; }

}