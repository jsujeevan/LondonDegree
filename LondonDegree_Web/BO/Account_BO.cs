using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class Account_BO
    {

        


        public List<AspNetUsersModel> SearchAspNetUsers(AspNetUsersModel in_aspNetUser_o)
        {
            List<AspNetUsersModel> vl_aspNetUserList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@Id", Parameter_Value = in_aspNetUser_o.Id , SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Email", Parameter_Value = in_aspNetUser_o.Email, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@UserName", Parameter_Value = in_aspNetUser_o.UserName, SqlDbType = SqlDbType.VarChar }
            };

            vl_sqlcmd_o.SQL_Name = "AspNetUsers_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_aspNetUserList_o = vl_dataBinder_o.GetGenericModel(typeof(AspNetUsersModel), vl_sqlcmd_o).Cast<AspNetUsersModel>().ToList();

            return vl_aspNetUserList_o;

        }

        public bool UpdateAspNetUsers(AspNetUsersModel in_aspNetUserModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@Id", Parameter_Value = in_aspNetUserModel_o.Id , SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Email", Parameter_Value = in_aspNetUserModel_o.Email, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@UserName", Parameter_Value = in_aspNetUserModel_o.UserName, SqlDbType = SqlDbType.VarChar }
            };

            vl_sqlcmd_o.SQL_Name = "AspNetUsers_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_aspNetUserModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeleteAspNetUsers(AspNetUsersModel in_aspNetUserModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@Id", Parameter_Value = in_aspNetUserModel_o.Id , SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "AspNetUsers_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_aspNetUserModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }


        public string GetClientBrowser(HttpRequestBase vl_Request_o)
        {
            string vl_browser_s = "";
            try
            {
                vl_browser_s = vl_Request_o.Browser.Browser;
            }
            catch (Exception e)
            {
                vl_browser_s = "";
            }
            return vl_browser_s;
        }

        public string GetClientBrowserInfo(HttpRequestBase vl_Request_o)
        {
            string vl_browserInfo_s = "";
            try
            {

                vl_browserInfo_s = "RemoteUser=" + vl_Request_o.ServerVariables["REMOTE_USER"] + ";\n"
                + "RemoteHost=" + vl_Request_o.ServerVariables["REMOTE_HOST"] + ";\n"
                + "Type=" + vl_Request_o.Browser.Type + ";\n"
                + "Name=" + vl_Request_o.Browser.Browser + ";\n"
                + "Version=" + vl_Request_o.Browser.Version + ";\n"
                + "MajorVersion=" + vl_Request_o.Browser.MajorVersion + ";\n"
                + "MinorVersion=" + vl_Request_o.Browser.MinorVersion + ";\n"
                + "Platform=" + vl_Request_o.Browser.Platform + ";\n"
                + "SupportsCookies=" + vl_Request_o.Browser.Cookies + ";\n"
                + "SupportsJavaScript=" + vl_Request_o.Browser.EcmaScriptVersion.ToString() + ";\n"
                + "SupportsActiveXControls=" + vl_Request_o.Browser.ActiveXControls + ";\n"
                + "SupportsJavaScriptVersion=" + vl_Request_o.Browser["JavaScriptVersion"] + "\n";
            }
            catch (Exception e)
            {
                vl_browserInfo_s = "";
            }
            return vl_browserInfo_s;
        }

        public string GetClientIP(HttpRequestBase vl_Request_o)
        {
            string vl_clientIPInfo_s = "";
            try
            {
                vl_clientIPInfo_s = (vl_Request_o.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? vl_Request_o.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
            }
            catch (Exception e)
            {
                vl_clientIPInfo_s = "";
            }
            return vl_clientIPInfo_s;
        }
    }
}