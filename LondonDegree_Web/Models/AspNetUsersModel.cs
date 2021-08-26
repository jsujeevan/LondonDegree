using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using LondonDegree_Web.BO;
namespace LondonDegree_Web.Models
{
     public class AspNetUsersModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Id")]
          [DataBinder(DataBinderName = "Id")]
          public string Id { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Email")]
          [DataBinder(DataBinderName = "Email")]
          public string Email { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "EmailConfirmed")]
          [DataBinder(DataBinderName = "EmailConfirmed")]
          public bool EmailConfirmed { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PasswordHash")]
          [DataBinder(DataBinderName = "PasswordHash")]
          public string PasswordHash { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "SecurityStamp")]
          [DataBinder(DataBinderName = "SecurityStamp")]
          public string SecurityStamp { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PhoneNumber")]
          [DataBinder(DataBinderName = "PhoneNumber")]
          public string PhoneNumber { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PhoneNumberConfirmed")]
          [DataBinder(DataBinderName = "PhoneNumberConfirmed")]
          public bool PhoneNumberConfirmed { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "TwoFactorEnabled")]
          [DataBinder(DataBinderName = "TwoFactorEnabled")]
          public bool TwoFactorEnabled { get; set; }

          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "LockoutEndDateUtc")]
          [DataBinder(DataBinderName = "LockoutEndDateUtc")]
          public DateTime LockoutEndDateUtc { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "LockoutEnabled")]
          [DataBinder(DataBinderName = "LockoutEnabled")]
          public bool LockoutEnabled { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "AccessFailedCount")]
          [DataBinder(DataBinderName = "AccessFailedCount")]
          public int AccessFailedCount { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "UserName")]
          [DataBinder(DataBinderName = "UserName")]
          public string UserName { get; set; }


          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "Modified_d")]
          [DataBinder(DataBinderName = "Modified_d")]
          public DateTime Modified_d { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FK_Person_Current_ID_s")]
        [DataBinder(DataBinderName = "FK_Person_Current_ID_s")]
        public Guid FK_Person_Current_ID_s { get; set; }

    }
}
