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
     public class EventSearchModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_Event_ID_s")]
          [DataBinder(DataBinderName = "PK_Event_ID_s")]
          public Guid PK_Event_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Event_Title_s")]
          [DataBinder(DataBinderName = "Event_Title_s")]
          public string Event_Title_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Event_Description_s")]
          [DataBinder(DataBinderName = "Event_Description_s")]
          public string Event_Description_s { get; set; }

          [Required]
          [DataType(DataType.DateTime)]
          [Display(Name = "Event_Start_Date_d")]
          [DataBinder(DataBinderName = "Event_Start_Date_d")]
          public DateTime Event_Start_Date_d { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Event_End_Date_d")]
        [DataBinder(DataBinderName = "Event_End_Date_d")]
        public DateTime Event_End_Date_d { get; set; }

        [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Event_Location_s")]
          [DataBinder(DataBinderName = "Event_Location_s")]
          public string Event_Location_s { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "Event_TargetAudience")]
          [DataBinder(DataBinderName = "Event_TargetAudience")]
          public string Event_TargetAudience_s { get; set; }

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

     }
}
