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
     public class PersonEnquiryStatusModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonEnquiryStatus_ID_i")]
          [DataBinder(DataBinderName = "PK_PersonEnquiryStatus_ID_i")]
          public int PK_PersonEnquiryStatus_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonEnquiryStatus_s")]
          [DataBinder(DataBinderName = "PersonEnquiryStatus_s")]
          public string PersonEnquiryStatus_s { get; set; }

     }
}
