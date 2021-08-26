using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class Email_BO
    {

        public EmailTemplateModel GetEmailTemplate(Guid in_id_gu)
        {
            EmailTemplateModel vl_templateModel_o = new EmailTemplateModel();
            List<EmailTemplateModel> vl_templateList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_EmailTemplate_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "EmailTemplate_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_templateList_o = vl_dataBinder_o.GetGenericModel(typeof(EmailTemplateModel), vl_sqlcmd_o).Cast<EmailTemplateModel>().ToList();
            if (vl_templateList_o.Count > 0)
            {
                vl_templateModel_o = vl_templateList_o.First();
            }

            return vl_templateModel_o;
        }

        public bool InsertEmail(EmailModel in_emailModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Email_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Email_Subject_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Email_Message_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Email_Sent_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@Email_Success_b",  SqlDbType = SqlDbType.Bit },
                new SQLParameterModel { Parameter_Name = "@FK_Person_To_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_From_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Email_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_emailModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

    }
}