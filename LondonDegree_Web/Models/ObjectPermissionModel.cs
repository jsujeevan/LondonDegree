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
     public class ObjectPermissionModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_ObjectPermission_ID_s")]
          [DataBinder(DataBinderName = "PK_ObjectPermission_ID_s")]
          public Guid PK_ObjectPermission_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Object_ID_s")]
          [DataBinder(DataBinderName = "FK_Object_ID_s")]
          public Guid FK_Object_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_ObjectRole_ID_i")]
          [DataBinder(DataBinderName = "FK_ObjectRole_ID_i")]
          public int FK_ObjectRole_ID_i { get; set; }

     }
}
