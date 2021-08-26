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
    public class ContactUsModel
    {

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

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Phone(Mobile)")]
        [DataBinder(DataBinderName = "Person_TelMobile_s")]
        public string Person_TelMobile_s { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Subject")]
        [DataBinder(DataBinderName = "Subject_s")]
        public string Subject_s { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Message")]
        [DataBinder(DataBinderName = "Message_s")]
        public string Message_s { get; set; }

    }
}