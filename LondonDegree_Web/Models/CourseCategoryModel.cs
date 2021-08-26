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
     public class CourseCategoryModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_CourseCategory_ID_i")]
          [DataBinder(DataBinderName = "PK_CourseCategory_ID_i")]
          public int PK_CourseCategory_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "CourseCategory_s")]
          [DataBinder(DataBinderName = "CourseCategory_s")]
          public string CourseCategory_s { get; set; }

     }
}
