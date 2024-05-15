﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExamenCertifac.Models;

[Index("UserName", Name = "UserNameIndex", IsUnique = true)]
public partial class AspNetUsers
{
    [Key]
    [StringLength(128)]
    public string Id { get; set; }

    [StringLength(256)]
    public string Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PasswordHash { get; set; }

    public string SecurityStamp { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LockoutEndDateUtc { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    [Required]
    [StringLength(256)]
    public string UserName { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; } = new List<AspNetUserClaims>();

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; } = new List<AspNetUserLogins>();

    [ForeignKey("UserId")]
    [InverseProperty("User")]
    public virtual ICollection<AspNetRoles> Role { get; set; } = new List<AspNetRoles>();
}