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
     public class ObjectTypeModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_ObjectType_ID_i")]
          [DataBinder(DataBinderName = "PK_ObjectType_ID_i")]
          public int PK_ObjectType_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "ObjectType_s")]
          [DataBinder(DataBinderName = "ObjectType_s")]
          public string ObjectType_s { get; set; }

     }
}
