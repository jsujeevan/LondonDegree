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
     public class PersonSessionModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonSession_ID_s")]
          [DataBinder(DataBinderName = "PK_PersonSession_ID_s")]
          public Guid PK_PersonSession_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_PersonLogin_ID_s")]
          [DataBinder(DataBinderName = "FK_PersonLogin_ID_s")]
          public Guid FK_PersonLogin_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonSession_Controller_s")]
          [DataBinder(DataBinderName = "PersonSession_Controller_s")]
          public string PersonSession_Controller_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonSession_Action_s")]
          [DataBinder(DataBinderName = "PersonSession_Action_s")]
          public string PersonSession_Action_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonSession_Parameter_s")]
          [DataBinder(DataBinderName = "PersonSession_Parameter_s")]
          public string PersonSession_Parameter_s { get; set; }

          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "PersonSession_Created_d")]
          [DataBinder(DataBinderName = "PersonSession_Created_d")]
          public DateTime PersonSession_Created_d { get; set; }

     }
}
