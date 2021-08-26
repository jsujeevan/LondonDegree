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
     public class PersonCourseStatusModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonCourseStatus_ID_i")]
          [DataBinder(DataBinderName = "PK_PersonCourseStatus_ID_i")]
          public int PK_PersonCourseStatus_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonCourseStatus_s")]
          [DataBinder(DataBinderName = "PersonCourseStatus_s")]
          public string PersonCourseStatus_s { get; set; }

     }
}
