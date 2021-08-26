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
     public class PersonEnquiryModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonEnquiry_ID_s")]
          [DataBinder(DataBinderName = "PK_PersonEnquiry_ID_s")]
          public Guid PK_PersonEnquiry_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Person")]
          [DataBinder(DataBinderName = "FK_Person_ID_s")]
          public Guid FK_Person_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Enquiry Subject")]
          [DataBinder(DataBinderName = "PersonEnquiry_s")]
          public string PersonEnquiry_s { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Reference")]
        [DataBinder(DataBinderName = "PersonEnquiry_Ref_s")]
        public string PersonEnquiry_Ref_s { get; set; }

        [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Message")]
          [DataBinder(DataBinderName = "PersonEnquiry_Message_s")]
          public string PersonEnquiry_Message_s { get; set; }

          [Required]
        [Range(1, 25, ErrorMessage = "Please select a status")]
        [Display(Name = "Status")]
          [DataBinder(DataBinderName = "FK_PersonEnquiryStatus_ID_i")]
          public int FK_PersonEnquiryStatus_ID_i { get; set; }

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


        [DataType(DataType.Text)]
        [Display(Name = "Firstname")]
        [DataBinder(DataBinderName = "Person_FirstName_s")]
        public string Person_FirstName_s { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Lastname")]
        [DataBinder(DataBinderName = "Person_LastName_s")]
        public string Person_LastName_s { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Status")]
        [DataBinder(DataBinderName = "PersonEnquiryStatus_s")]
        public string PersonEnquiryStatus_s { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FK_Person_Current_ID_s")]
        [DataBinder(DataBinderName = "FK_Person_Current_ID_s")]
        public Guid FK_Person_Current_ID_s { get; set; }

    }
}
