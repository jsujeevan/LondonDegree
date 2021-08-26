using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class Provider_BO
    {

        public List<ProviderModel> SearchProvider(ProviderModel in_provider_o)
        {
            List<ProviderModel> vl_providerList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@Provider_s", Parameter_Value = in_provider_o.Provider_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_AddressLine1_s", Parameter_Value = in_provider_o.Provider_AddressLine1_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_AddressLine2_s", Parameter_Value = in_provider_o.Provider_AddressLine2_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_Town_s", Parameter_Value = in_provider_o.Provider_Town_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_County_s", Parameter_Value = in_provider_o.Provider_County_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_Postcode_s", Parameter_Value = in_provider_o.Provider_Postcode_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Country_ID_i", Parameter_Value = in_provider_o.FK_Country_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_provider_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", Parameter_Value = in_provider_o.Created_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_provider_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_provider_o.Modified_d, SqlDbType = SqlDbType.DateTime }
            };

            vl_sqlcmd_o.SQL_Name = "Provider_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_providerList_o = vl_dataBinder_o.GetGenericModel(typeof(ProviderModel), vl_sqlcmd_o).Cast<ProviderModel>().ToList();

            return vl_providerList_o;

        }


        public ProviderModel GetProvider(Guid in_id_gu)
        {
            ProviderModel vl_ProviderModel_o = new ProviderModel();
            List<ProviderModel> vl_providerList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Provider_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Provider_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_providerList_o = vl_dataBinder_o.GetGenericModel(typeof(ProviderModel), vl_sqlcmd_o).Cast<ProviderModel>().ToList();
            if (vl_providerList_o.Count > 0)
            {
                vl_ProviderModel_o = vl_providerList_o.First();
            }

            return vl_ProviderModel_o;

        }

        public bool UpdateProvider(ProviderModel in_provider_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Provider_ID_s", Parameter_Value = in_provider_o.PK_Provider_ID_gu , SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Provider_s", Parameter_Value = in_provider_o.Provider_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_AddressLine1_s", Parameter_Value = in_provider_o.Provider_AddressLine1_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_AddressLine2_s", Parameter_Value = in_provider_o.Provider_AddressLine2_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_Town_s", Parameter_Value = in_provider_o.Provider_Town_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_County_s", Parameter_Value = in_provider_o.Provider_County_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_Postcode_s", Parameter_Value = in_provider_o.Provider_Postcode_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Country_ID_i", Parameter_Value = in_provider_o.FK_Country_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_provider_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_provider_o.Modified_d, SqlDbType = SqlDbType.DateTime }


            };

            vl_sqlcmd_o.SQL_Name = "Provider_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_provider_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertProvider(ProviderModel in_provider_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Provider_ID_s", Parameter_Value = in_provider_o.PK_Provider_ID_gu , SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Provider_s", Parameter_Value = in_provider_o.Provider_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_AddressLine1_s", Parameter_Value = in_provider_o.Provider_AddressLine1_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_AddressLine2_s", Parameter_Value = in_provider_o.Provider_AddressLine2_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_Town_s", Parameter_Value = in_provider_o.Provider_Town_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_County_s", Parameter_Value = in_provider_o.Provider_County_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Provider_Postcode_s", Parameter_Value = in_provider_o.Provider_Postcode_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Country_ID_i", Parameter_Value = in_provider_o.FK_Country_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_provider_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", Parameter_Value = in_provider_o.FK_Person_Current_ID_s, SqlDbType = SqlDbType.UniqueIdentifier },
                

            };

            vl_sqlcmd_o.SQL_Name = "Provider_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_provider_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeleteProvider(ProviderModel in_ProviderModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Provider_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Provider_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_ProviderModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

    }
}