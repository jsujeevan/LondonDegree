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
     public class PersonAddressTypeModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonAddressType_ID_i")]
          [DataBinder(DataBinderName = "PK_PersonAddressType_ID_i")]
          public int PK_PersonAddressType_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonAddressType_s")]
          [DataBinder(DataBinderName = "PersonAddressType_s")]
          public string PersonAddressType_s { get; set; }

     }
}
