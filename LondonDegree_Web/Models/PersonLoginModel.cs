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
     public class PersonLoginModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonLogin_ID_s")]
          [DataBinder(DataBinderName = "PK_PersonLogin_ID_s")]
          public Guid PK_PersonLogin_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Person_ID_s")]
          [DataBinder(DataBinderName = "FK_Person_ID_s")]
          public Guid FK_Person_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonLogin_Username_s")]
          [DataBinder(DataBinderName = "PersonLogin_Username_s")]
          public string PersonLogin_Username_s { get; set; }

          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "PersonLogin_Login_d")]
          [DataBinder(DataBinderName = "PersonLogin_Login_d")]
          public DateTime PersonLogin_Login_d { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonLogin_Success_b")]
          [DataBinder(DataBinderName = "PersonLogin_Success_b")]
          public bool PersonLogin_Success_z { get; set; }

          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "PersonLogin_Logout_d")]
          [DataBinder(DataBinderName = "PersonLogin_Logout_d")]
          public DateTime PersonLogin_Logout_d { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonLogin_Browser_s")]
          [DataBinder(DataBinderName = "PersonLogin_Browser_s")]
          public string PersonLogin_Browser_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonLogin_IP_s")]
          [DataBinder(DataBinderName = "PersonLogin_IP_s")]
          public string PersonLogin_IP_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonLogin_BrowserDetails_s")]
          [DataBinder(DataBinderName = "PersonLogin_BrowserDetails_s")]
          public string PersonLogin_BrowserDetails_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonLogin_Attempt_i")]
          [DataBinder(DataBinderName = "PersonLogin_Attempt_i")]
          public int PersonLogin_Attempt_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonLogin_Impersonate_b")]
          [DataBinder(DataBinderName = "PersonLogin_Impersonate_b")]
          public bool PersonLogin_Impersonate_z { get; set; }

     }
}
