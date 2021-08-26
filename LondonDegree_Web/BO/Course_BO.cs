using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class Course_BO
    {

        public List<CourseModel> SearchCourse(CourseModel in_course_o)
        {
            List<CourseModel> vl_courseList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>();

            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Course_Name_s", Parameter_Value = in_course_o.Course_Name_s, SqlDbType = SqlDbType.VarChar });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Course_Introduction_s", Parameter_Value = in_course_o.Course_Introduction_s, SqlDbType = SqlDbType.VarChar });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Course_Structure_s", Parameter_Value = in_course_o.Course_Structure_s, SqlDbType = SqlDbType.VarChar });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Course_PricesAndDates_s", Parameter_Value = in_course_o.Course_PricesAndDates_s, SqlDbType = SqlDbType.VarChar });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Course_HowToApply_s", Parameter_Value = in_course_o.Course_HowToApply_s, SqlDbType = SqlDbType.VarChar });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Course_OtherDetails_s", Parameter_Value = in_course_o.Course_OtherDetails_s, SqlDbType = SqlDbType.VarChar });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@FK_Provider_ID_s", Parameter_Value = in_course_o.FK_Provider_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@FK_CourseCategory_ID_i", Parameter_Value = in_course_o.FK_CourseCategory_ID_i, SqlDbType = SqlDbType.Int });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@FK_CourseLevel_ID_i", Parameter_Value = in_course_o.FK_CourseLevel_ID_i, SqlDbType = SqlDbType.Int });
            if (in_course_o.Course_Provider_Hidden_Specified_z) {
                vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Course_Provider_Hidden_b", Parameter_Value = in_course_o.Course_Provider_Hidden_z, SqlDbType = SqlDbType.Bit });
            }
            if (in_course_o.Course_Hidden_Specified_z) {
                vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Course_Hidden_b", Parameter_Value = in_course_o.Course_Hidden_z, SqlDbType = SqlDbType.Bit });
            }
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_course_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Created_d", Parameter_Value = in_course_o.Created_d, SqlDbType = SqlDbType.DateTime });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_course_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier });
            vl_paramList.Add(new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_course_o.Modified_d, SqlDbType = SqlDbType.DateTime });

            vl_sqlcmd_o.SQL_Name = "Course_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_courseList_o = vl_dataBinder_o.GetGenericModel(typeof(CourseModel), vl_sqlcmd_o).Cast<CourseModel>().ToList();

            return vl_courseList_o;

        }


        public CourseModel GetCourse(Guid in_id_gu)
        {
            CourseModel vl_CourseModel_o = new CourseModel();
            List<CourseModel> vl_courseList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Course_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Course_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_courseList_o = vl_dataBinder_o.GetGenericModel(typeof(CourseModel), vl_sqlcmd_o).Cast<CourseModel>().ToList();
            if (vl_courseList_o.Count > 0)
            {
                vl_CourseModel_o = vl_courseList_o.First();
            }

            return vl_CourseModel_o;

        }

        public bool UpdateCourse(CourseModel in_CourseModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Course_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Course_Name_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_Introduction_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_Structure_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_PricesAndDates_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_HowToApply_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_OtherDetails_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Provider_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_CourseCategory_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_CourseLevel_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@Course_Provider_Hidden_b", SqlDbType = SqlDbType.Bit },
                new SQLParameterModel { Parameter_Name = "@Course_Hidden_b", SqlDbType = SqlDbType.Bit },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },


            };

            vl_sqlcmd_o.SQL_Name = "Course_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_CourseModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertCourse(CourseModel in_CourseModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Course_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Course_Name_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_Introduction_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_Structure_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_PricesAndDates_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_HowToApply_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Course_OtherDetails_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Provider_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_CourseCategory_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_CourseLevel_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@Course_Provider_Hidden_b", SqlDbType = SqlDbType.Bit },
                new SQLParameterModel { Parameter_Name = "@Course_Hidden_b", SqlDbType = SqlDbType.Bit },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Course_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_CourseModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeleteCourse(CourseModel in_CourseModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Course_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Course_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_CourseModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }


        public List<CourseCategoryModel> SearchCourseCategory(CourseCategoryModel in_courseCategory_o)
        {
            List<CourseCategoryModel> vl_courseCategoryList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_CourseCategory_ID_i", Parameter_Value = in_courseCategory_o.PK_CourseCategory_ID_i , SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@CourseCategory_s", Parameter_Value = in_courseCategory_o.CourseCategory_s, SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "CourseCategory_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_courseCategoryList_o = vl_dataBinder_o.GetGenericModel(typeof(CourseCategoryModel), vl_sqlcmd_o).Cast<CourseCategoryModel>().ToList();

            return vl_courseCategoryList_o;

        }

        public List<CourseLevelModel> SearchCourseLevel(CourseLevelModel in_courseLevel_o)
        {
            List<CourseLevelModel> vl_courseLevelList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_CourseLevel_ID_i", Parameter_Value = in_courseLevel_o.PK_CourseLevel_ID_i , SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@CourseLevel_s", Parameter_Value = in_courseLevel_o.CourseLevel_s, SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "CourseLevel_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_courseLevelList_o = vl_dataBinder_o.GetGenericModel(typeof(CourseLevelModel), vl_sqlcmd_o).Cast<CourseLevelModel>().ToList();

            return vl_courseLevelList_o;

        }

    }
}