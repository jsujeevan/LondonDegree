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
     public class EmailModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_Email_ID_s")]
          [DataBinder(DataBinderName = "PK_Email_ID_s")]
          public Guid PK_Email_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Email_Subject_s")]
          [DataBinder(DataBinderName = "Email_Subject_s")]
          public string Email_Subject_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Email_Message_s")]
          [DataBinder(DataBinderName = "Email_Message_s")]
          public string Email_Message_s { get; set; }

          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "Email_Sent_d")]
          [DataBinder(DataBinderName = "Email_Sent_d")]
          public DateTime Email_Sent_d { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Email_Success_b")]
          [DataBinder(DataBinderName = "Email_Success_b")]
          public bool Email_Success_z { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Person_To_ID_s")]
          [DataBinder(DataBinderName = "FK_Person_To_ID_s")]
          public Guid FK_Person_To_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Person_From_ID_s")]
          [DataBinder(DataBinderName = "FK_Person_From_ID_s")]
          public Guid FK_Person_From_ID_gu { get; set; }


          public string Person_To_Email_s { get; set; }

    }
}
