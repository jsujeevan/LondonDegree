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
     public class CourseModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_Course_ID_s")]
          [DataBinder(DataBinderName = "PK_Course_ID_s")]
          public Guid PK_Course_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Name")]
          [DataBinder(DataBinderName = "Course_Name_s")]
          public string Course_Name_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Introduction")]
          [DataBinder(DataBinderName = "Course_Introduction_s")]
          public string Course_Introduction_s { get; set; }


          [DataType(DataType.Text)]
          [Display(Name = "Structure")]
          [DataBinder(DataBinderName = "Course_Structure_s")]
          public string Course_Structure_s { get; set; }


          [DataType(DataType.Text)]
          [Display(Name = "Prices and Dates")]
          [DataBinder(DataBinderName = "Course_PricesAndDates_s")]
          public string Course_PricesAndDates_s { get; set; }

 
          [DataType(DataType.Text)]
          [Display(Name = "How to Apply")]
          [DataBinder(DataBinderName = "Course_HowToApply_s")]
          public string Course_HowToApply_s { get; set; }


          [DataType(DataType.Text)]
          [Display(Name = "Other Details")]
          [DataBinder(DataBinderName = "Course_OtherDetails_s")]
          public string Course_OtherDetails_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Provider_ID_s")]
          [DataBinder(DataBinderName = "FK_Provider_ID_s")]
          public Guid FK_Provider_ID_gu { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Provider_s")]
        [DataBinder(DataBinderName = "Provider_s")]
        public string Provider_s { get; set; }

        [Required]
        [Range(1, 25, ErrorMessage = "Please select category")]
        [Display(Name = "FK_CourseCategory_ID_i")]
          [DataBinder(DataBinderName = "FK_CourseCategory_ID_i")]
          public int FK_CourseCategory_ID_i { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "CourseCategory_s")]
        [DataBinder(DataBinderName = "CourseCategory_s")]
        public string CourseCategory_s { get; set; }

        [Required]
        [Range(1, 25, ErrorMessage = "Please select level")]
        [Display(Name = "FK_CourseLevel_ID_i")]
          [DataBinder(DataBinderName = "FK_CourseLevel_ID_i")]
          public int FK_CourseLevel_ID_i { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "CourseLevel_s")]
        [DataBinder(DataBinderName = "CourseLevel_s")]
        public string CourseLevel_s { get; set; }

  
          [DataType(DataType.Text)]
          [Display(Name = "Course_Provider_Hidden_b")]
          [DataBinder(DataBinderName = "Course_Provider_Hidden_b")]
          public bool Course_Provider_Hidden_z { get; set; }

        public bool Course_Provider_Hidden_Specified_z { get; set; }

        [DataType(DataType.Text)]
          [Display(Name = "Course_Hidden_b")]
          [DataBinder(DataBinderName = "Course_Hidden_b")]
          public bool Course_Hidden_z { get; set; }

        public bool Course_Hidden_Specified_z { get; set; }

        [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Person_Created_ID_s")]
          [DataBinder(DataBinderName = "FK_Person_Created_ID_s")]
          public Guid FK_Person_Created_ID_gu { get; set; }

          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "Created_d")]
          [DataBinder(DataBinderName = "Created_d")]
          public DateTime Created_d { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Person_Modified_ID_s")]
          [DataBinder(DataBinderName = "FK_Person_Modified_ID_s")]
          public Guid FK_Person_Modified_ID_gu { get; set; }

          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "Modified_d")]
          [DataBinder(DataBinderName = "Modified_d")]
          public DateTime Modified_d { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FK_Person_Current_ID_s")]
        [DataBinder(DataBinderName = "FK_Person_Current_ID_s")]
        public Guid FK_Person_Current_ID_s { get; set; }

    }
}
