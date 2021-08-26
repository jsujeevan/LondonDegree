using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class Event_BO
    {

        public List<EventModel> SearchEvent(EventSearchModel in_eventSearch_o)
        {
            List<EventModel> vl_eventList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@Event_Title_s", Parameter_Value = in_eventSearch_o.Event_Title_s , SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Event_Description_s", Parameter_Value = in_eventSearch_o.Event_Description_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Event_Start_Date_d", Parameter_Value = in_eventSearch_o.Event_Start_Date_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@Event_End_Date_d", Parameter_Value = in_eventSearch_o.Event_End_Date_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@Event_Location_s", Parameter_Value = in_eventSearch_o.Event_Location_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Event_TargetAudience", Parameter_Value = in_eventSearch_o.Event_TargetAudience_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_eventSearch_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", Parameter_Value = in_eventSearch_o.Created_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_eventSearch_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_eventSearch_o.Modified_d, SqlDbType = SqlDbType.DateTime }
            };

            vl_sqlcmd_o.SQL_Name = "Event_Search_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_eventList_o = vl_dataBinder_o.GetGenericModel(typeof(EventModel), vl_sqlcmd_o).Cast<EventModel>().ToList();

            return vl_eventList_o;

        }


        public EventModel GetEvent(Guid in_id_gu)
        {
            EventModel vl_eventModel_o = new EventModel();
            List<EventModel> vl_eventList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Event_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Event_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_eventList_o = vl_dataBinder_o.GetGenericModel(typeof(EventModel), vl_sqlcmd_o).Cast<EventModel>().ToList();
            if (vl_eventList_o.Count > 0)
            {
                vl_eventModel_o = vl_eventList_o.First();
            }

            return vl_eventModel_o;

        }

        public bool UpdateEvent(EventModel in_eventModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Event_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Event_Title_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Event_Description_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Event_Date_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@Event_Location_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Event_TargetAudience", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Event_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_eventModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertEvent(EventModel in_eventModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Event_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Event_Title_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Event_Description_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Event_Date_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@Event_Location_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Event_TargetAudience", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Event_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_eventModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeleteEvent(EventModel in_eventModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Event_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_eventModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }


        public List<NewsModel> SearchNews(NewsSearchModel in_newsSearch_o)
        {
            List<NewsModel> vl_newsList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@News_Title_s", Parameter_Value = in_newsSearch_o.News_Title_s , SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@News_HeadLine_s", Parameter_Value = in_newsSearch_o.News_HeadLine_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@News_s", Parameter_Value = in_newsSearch_o.News_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@News_Published_Start_d", Parameter_Value = in_newsSearch_o.News_Published_Start_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@News_Published_End_d", Parameter_Value = in_newsSearch_o.News_Published_End_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Published_ID_s", Parameter_Value = in_newsSearch_o.FK_Person_Published_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_newsSearch_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", Parameter_Value = in_newsSearch_o.Created_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_newsSearch_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_newsSearch_o.Modified_d, SqlDbType = SqlDbType.DateTime }
            };

            vl_sqlcmd_o.SQL_Name = "News_Search_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_newsList_o = vl_dataBinder_o.GetGenericModel(typeof(NewsModel), vl_sqlcmd_o).Cast<NewsModel>().ToList();

            return vl_newsList_o;

        }


        public NewsModel GetNews(Guid in_id_gu)
        {
            NewsModel vl_newsModel_o = new NewsModel();
            List<NewsModel> vl_newsList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_News_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "News_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_newsList_o = vl_dataBinder_o.GetGenericModel(typeof(NewsModel), vl_sqlcmd_o).Cast<NewsModel>().ToList();
            if (vl_newsList_o.Count > 0)
            {
                vl_newsModel_o = vl_newsList_o.First();
            }

            return vl_newsModel_o;

        }

        public bool UpdateNews(NewsModel in_newsModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {

                new SQLParameterModel { Parameter_Name = "@PK_News_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@News_Title_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@News_HeadLine_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@News_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@News_Published_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Published_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@News_ThumbnailImage_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "News_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_newsModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertNews(NewsModel in_newsModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_News_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@News_Title_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@News_HeadLine_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@News_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@News_Published_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Published_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@News_ThumbnailImage_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "News_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_newsModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeleteNews(NewsModel in_newsModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_News_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "News_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_newsModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

    }
}