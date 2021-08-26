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
     public class PersonCourseModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonCourse_ID_s")]
          [DataBinder(DataBinderName = "PK_PersonCourse_ID_s")]
          public Guid PK_PersonCourse_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Person_ID_s")]
          [DataBinder(DataBinderName = "FK_Person_ID_s")]
          public Guid FK_Person_ID_gu { get; set; }

          [Required(ErrorMessage = "Please select a course")]
          [DataType(DataType.Text)]
          [Display(Name = "Course")]
          [DataBinder(DataBinderName = "FK_Course_ID_s")]
          public Guid FK_Course_ID_gu { get; set; }

        
          [DataType(DataType.Text)]
          [Display(Name = "Provider ID")]
          [DataBinder(DataBinderName = "FK_Provider_ID_s")]
          public Guid FK_Provider_ID_s { get; set; }

        [Required]
          [Range(1, 25, ErrorMessage = "Please select a status")]
        [Display(Name = "FK_PersonCourseStatus_ID_i")]
          [DataBinder(DataBinderName = "FK_PersonCourseStatus_ID_i")]
          public int FK_PersonCourseStatus_ID_i { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Enquiry")]
        [DataBinder(DataBinderName = "DateOfEnquiry_d")]
        public DateTime DateOfEnquiry_d { get; set; }

        
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Enrolment")]
        [DataBinder(DataBinderName = "DateOfEnrolment_d")]
        public DateTime DateOfEnrolment_d { get; set; }


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

        
          [DataType(DataType.Text)]
          [Display(Name = "Status")]
          [DataBinder(DataBinderName = "PersonCourseStatus_s")]
          public string PersonCourseStatus_s { get; set; }

        [DataType(DataType.Text)]
          [Display(Name = "Firstname")]
          [DataBinder(DataBinderName = "Person_FirstName_s")]
          public string Person_FirstName_s { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Lastname")]
        [DataBinder(DataBinderName = "Person_LastName_s")]
        public string Person_LastName_s { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        [DataBinder(DataBinderName = "Person_Email_s")]
        public string Person_Email_s { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Phone(Mobile)")]
        [DataBinder(DataBinderName = "Person_TelMobile_s")]
        public string Person_TelMobile_s { get; set; }

 
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        [DataBinder(DataBinderName = "Course_Name_s")]
        public string Course_Name_s { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Provider_s")]
        [DataBinder(DataBinderName = "Provider_s")]
        public string Provider_s { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "CourseCategory_s")]
        [DataBinder(DataBinderName = "CourseCategory_s")]
        public string CourseCategory_s { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "CourseLevel_s")]
        [DataBinder(DataBinderName = "CourseLevel_s")]
        public string CourseLevel_s { get; set; }
    }
}
