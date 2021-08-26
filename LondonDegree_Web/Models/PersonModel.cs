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
     public class PersonModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_Person_ID_s")]
          [DataBinder(DataBinderName = "PK_Person_ID_s")]
          public Guid PK_Person_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Firstname")]
          [DataBinder(DataBinderName = "Person_FirstName_s")]
          public string Person_FirstName_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Lastname")]
          [DataBinder(DataBinderName = "Person_LastName_s")]
          public string Person_LastName_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataBinder(DataBinderName = "Person_Email_s")]
          public string Person_Email_s { get; set; }

        
        [DataType(DataType.Text)]
        [Display(Name = "Pen Portrait")]
        [DataBinder(DataBinderName = "Person_Portrait_s")]
        public string Person_Portrait_s { get; set; }

        [Required]
        [DataType(DataType.Text)]
          [Display(Name = "Phone(Mobile)")]
          [DataBinder(DataBinderName = "Person_TelMobile_s")]
          public string Person_TelMobile_s { get; set; }


          [DataType(DataType.Text)]
          [Display(Name = "Phone(Home)")]
          [DataBinder(DataBinderName = "Person_TelHome_s")]
          public string Person_TelHome_s { get; set; }


        [Required]
        [Range(1, 25, ErrorMessage = "Please select status")]
        [Display(Name = "Status")]
          [DataBinder(DataBinderName = "FK_PersonStatus_ID_i")]
          public int FK_PersonStatus_ID_i { get; set; }

 
        [Required]
        [Range(1, 25, ErrorMessage = "Please select role")]
        [Display(Name = "Role")]
          [DataBinder(DataBinderName = "FK_PersonRole_ID_i")]
          public int FK_PersonRole_ID_i { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Status")]
        [DataBinder(DataBinderName = "PersonStatus_s")]
        public string PersonStatus_s { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Role")]
        [DataBinder(DataBinderName = "PersonRole_s")]
        public string PersonRole_s { get; set; }

        [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Person_Archive_b")]
          [DataBinder(DataBinderName = "Person_Archive_b")]
          public bool Person_Archive_z { get; set; }

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
        [Display(Name = "Membership ID")]
        [DataBinder(DataBinderName = "Id")]
        public string Membership_s { get; set; }

    }
}
