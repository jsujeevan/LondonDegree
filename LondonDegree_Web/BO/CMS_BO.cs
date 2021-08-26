using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class CMS_BO
    {

        public List<ServiceModel> SearchService(ServiceModel in_service_o)
        {
            List<ServiceModel> vl_serviceList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@Service_Title_s", Parameter_Value = in_service_o.Service_Title_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Service_Introduction_s", Parameter_Value = in_service_o.Service_Introduction_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Service_Description_s", Parameter_Value = in_service_o.Service_Description_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Service_Order_i", Parameter_Value = in_service_o.Service_Order_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_service_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", Parameter_Value = in_service_o.Created_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_service_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_service_o.Modified_d, SqlDbType = SqlDbType.DateTime }
            };

            vl_sqlcmd_o.SQL_Name = "Service_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_serviceList_o = vl_dataBinder_o.GetGenericModel(typeof(ServiceModel), vl_sqlcmd_o).Cast<ServiceModel>().ToList();

            return vl_serviceList_o;

        }


        public ServiceModel GetService(Guid in_id_gu)
        {
            ServiceModel vl_serviceModel_o = new ServiceModel();
            List<ServiceModel> vl_serviceList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Service_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Service_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_serviceList_o = vl_dataBinder_o.GetGenericModel(typeof(ServiceModel), vl_sqlcmd_o).Cast<ServiceModel>().ToList();
            if (vl_serviceList_o.Count > 0)
            {
                vl_serviceModel_o = vl_serviceList_o.First();
            }

            return vl_serviceModel_o;

        }

        public bool UpdateService(ServiceModel in_serviceModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Service_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Service_Title_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Service_Introduction_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Service_Description_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Service_Order_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Service_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_serviceModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertService(ServiceModel in_serviceModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Service_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Service_Title_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Service_Introduction_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Service_Description_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Service_Order_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Service_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_serviceModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeleteService(ServiceModel in_serviceModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Service_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Service_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_serviceModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

    }
}