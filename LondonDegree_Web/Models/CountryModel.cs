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
     public class CountryModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_Country_ID_i")]
          [DataBinder(DataBinderName = "PK_Country_ID_i")]
          public int PK_Country_ID_i { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Country_s")]
          [DataBinder(DataBinderName = "Country_s")]
          public string Country_s { get; set; }

     }
}
