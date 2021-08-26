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
     public class NewsModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_News_ID_s")]
          [DataBinder(DataBinderName = "PK_News_ID_s")]
          public Guid PK_News_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Title")]
          [DataBinder(DataBinderName = "News_Title_s")]
          public string News_Title_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Headline")]
          [DataBinder(DataBinderName = "News_HeadLine_s")]
          public string News_HeadLine_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "News")]
          [DataBinder(DataBinderName = "News_s")]
          public string News_s { get; set; }

          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "Published Date")]
          [DataBinder(DataBinderName = "News_Published_d")]
          public DateTime News_Published_d { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Publisher")]
          [DataBinder(DataBinderName = "FK_Person_Published_ID_s")]
          public Guid FK_Person_Published_ID_gu { get; set; }

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
          [Display(Name = "News_ThumbnailImage_s")]
          [DataBinder(DataBinderName = "News_ThumbnailImage_s")]
          public string News_ThumbnailImage_s { get; set; }

        
                      [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_Person_Current_ID_s")]
          [DataBinder(DataBinderName = "FK_Person_Current_ID_s")]
          public Guid FK_Person_Current_ID_s { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Person_s")]
        [DataBinder(DataBinderName = "Person_s")]
        public string Person_s { get; set; }
    }
}
