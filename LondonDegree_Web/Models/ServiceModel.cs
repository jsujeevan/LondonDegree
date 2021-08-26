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
     public class ServiceModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_Service_ID_s")]
          [DataBinder(DataBinderName = "PK_Service_ID_s")]
          public Guid PK_Service_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Title")]
          [DataBinder(DataBinderName = "Service_Title_s")]
          public string Service_Title_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Introduction")]
          [DataBinder(DataBinderName = "Service_Introduction_s")]
          public string Service_Introduction_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Description")]
          [DataBinder(DataBinderName = "Service_Description_s")]
          public string Service_Description_s { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Please select display order")]
        [Display(Name = "Display Order")]
        [DataBinder(DataBinderName = "Service_Order_i")]
        public int Service_Order_i { get; set; }

 
          [DataType(DataType.Text)]
          [Display(Name = "Service_Image_s")]
          [DataBinder(DataBinderName = "Service_Image_s")]
          public string Service_Image_s { get; set; }


          [DataType(DataType.Text)]
          [Display(Name = "Service_IndexImage_s")]
          [DataBinder(DataBinderName = "Service_IndexImage_s")]
          public string Service_IndexImage_s { get; set; }

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
