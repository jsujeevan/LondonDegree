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
     public class PersonEnquiryCommunicationModel : GenericModel
     {

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PK_PersonEnquiryCommunication_ID_s")]
          [DataBinder(DataBinderName = "PK_PersonEnquiryCommunication_ID_s")]
          public Guid PK_PersonEnquiryCommunication_ID_gu { get; set; }

          [Required]
          [DataType(DataType.Text)]
          [Display(Name = "FK_PersonEnquiry_ID_s")]
          [DataBinder(DataBinderName = "FK_PersonEnquiry_ID_s")]
          public Guid FK_PersonEnquiry_ID_gu { get; set; }


        [Required]
          [DataType(DataType.Text)]
          [Display(Name = "PersonEnquiryCommunication_s")]
          [DataBinder(DataBinderName = "PersonEnquiryCommunication_s")]
          public string PersonEnquiryCommunication_s { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "PersonCreated_s")]
        [DataBinder(DataBinderName = "PersonCreated_s")]
        public string PersonCreated_s { get; set; }

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


        public bool EmailRequired_z { get; set; }

        [Required]
          [DataType(DataType.Text)]
          [Display(Name = "EmailSent_b")]
          [DataBinder(DataBinderName = "EmailSent_b")]
          public bool EmailSent_z { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FK_Person_Current_ID_s")]
        [DataBinder(DataBinderName = "FK_Person_Current_ID_s")]
        public Guid FK_Person_Current_ID_s { get; set; }

    }
}
