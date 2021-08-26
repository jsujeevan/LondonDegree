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
     public class EmailTemplateModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_EmailTemplate_ID_s")]
          [DataBinder(DataBinderName = "PK_EmailTemplate_ID_s")]
          public Guid PK_EmailTemplate_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "EmailTemplate_Name_s")]
          [DataBinder(DataBinderName = "EmailTemplate_Name_s")]
          public string EmailTemplate_Name_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "EmailTemplate_Message_s")]
          [DataBinder(DataBinderName = "EmailTemplate_Message_s")]
          public string EmailTemplate_Message_s { get; set; }

     }
}
