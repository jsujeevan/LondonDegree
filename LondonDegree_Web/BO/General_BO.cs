using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class General_BO
    {
        public List<CountryModel> SearchCountry(CountryModel in_country_o)
        {
            List<CountryModel> vl_countryList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Country_ID_i", Parameter_Value = in_country_o.PK_Country_ID_i , SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@Country_s", Parameter_Value = in_country_o.Country_s, SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "Country_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_countryList_o = vl_dataBinder_o.GetGenericModel(typeof(CountryModel), vl_sqlcmd_o).Cast<CountryModel>().ToList();

            return vl_countryList_o;

        }
    }
}