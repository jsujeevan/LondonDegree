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
     public class PersonRoleModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonRole_ID_i")]
          [DataBinder(DataBinderName = "PK_PersonRole_ID_i")]
          public int PK_PersonRole_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonRole_s")]
          [DataBinder(DataBinderName = "PersonRole_s")]
          public string PersonRole_s { get; set; }

     }
}
