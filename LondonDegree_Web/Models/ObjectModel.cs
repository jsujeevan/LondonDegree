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
     public class ObjectModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_Object_ID_s")]
          [DataBinder(DataBinderName = "PK_Object_ID_s")]
          public Guid PK_Object_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Object_s")]
          [DataBinder(DataBinderName = "Object_s")]
          public string Object_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Object_Controller_s")]
          [DataBinder(DataBinderName = "Object_Controller_s")]
          public string Object_Controller_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Object_Action_s")]
          [DataBinder(DataBinderName = "Object_Action_s")]
          public string Object_Action_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Object_Label_s")]
          [DataBinder(DataBinderName = "Object_Label_s")]
          public string Object_Label_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Object_Thumbnail_s")]
          [DataBinder(DataBinderName = "Object_Thumbnail_s")]
          public string Object_Thumbnail_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Object_Order_i")]
          [DataBinder(DataBinderName = "Object_Order_i")]
          public int Object_Order_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_ObjectType_ID_i")]
          [DataBinder(DataBinderName = "FK_ObjectType_ID_i")]
          public int FK_ObjectType_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Object_Parent_ID_s")]
          [DataBinder(DataBinderName = "FK_Object_Parent_ID_s")]
          public Guid FK_Object_Parent_ID_gu { get; set; }

          public LinkedList<ObjectModel> Children { get; set; }

    }
}
