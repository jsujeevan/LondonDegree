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
     public class CourseLevelModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_CourseLevel_ID_i")]
          [DataBinder(DataBinderName = "PK_CourseLevel_ID_i")]
          public int PK_CourseLevel_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "CourseLevel_s")]
          [DataBinder(DataBinderName = "CourseLevel_s")]
          public string CourseLevel_s { get; set; }

     }
}
