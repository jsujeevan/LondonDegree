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
     public class ObjectRoleModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_ObjectRole_ID_i")]
          [DataBinder(DataBinderName = "PK_ObjectRole_ID_i")]
          public int PK_ObjectRole_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "ObjectRole_s")]
          [DataBinder(DataBinderName = "ObjectRole_s")]
          public string ObjectRole_s { get; set; }

     }
}
