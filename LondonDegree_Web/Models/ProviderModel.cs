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
     public class ProviderModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_Provider_ID_s")]
          [DataBinder(DataBinderName = "PK_Provider_ID_s")]
          public Guid PK_Provider_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Name")]
          [DataBinder(DataBinderName = "Provider_s")]
          public string Provider_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Address Line 1")]
          [DataBinder(DataBinderName = "Provider_AddressLine1_s")]
          public string Provider_AddressLine1_s { get; set; }

          
          [DataType(DataType.Text)]
          [Display(Name = "Address Line 2")]
          [DataBinder(DataBinderName = "Provider_AddressLine2_s")]
          public string Provider_AddressLine2_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Town")]
          [DataBinder(DataBinderName = "Provider_Town_s")]
          public string Provider_Town_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "County")]
          [DataBinder(DataBinderName = "Provider_County_s")]
          public string Provider_County_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Postcode")]
          [DataBinder(DataBinderName = "Provider_Postcode_s")]
          public string Provider_Postcode_s { get; set; }

          [Required]
        [Range(1, 250, ErrorMessage = "Please select country")]
        [Display(Name = "Country")]
          [DataBinder(DataBinderName = "FK_Country_ID_i")]
          public int FK_Country_ID_i { get; set; }

        
          [DataType(DataType.Text)]
          [Display(Name = "Country")]
          [DataBinder(DataBinderName = "Country_s")]
          public string Country_s { get; set; }

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
