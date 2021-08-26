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
     public class PersonStatusModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonStatus_ID_i")]
          [DataBinder(DataBinderName = "PK_PersonStatus_ID_i")]
          public int PK_PersonStatus_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonStatus_s")]
          [DataBinder(DataBinderName = "PersonStatus_s")]
          public string PersonStatus_s { get; set; }

     }
}
