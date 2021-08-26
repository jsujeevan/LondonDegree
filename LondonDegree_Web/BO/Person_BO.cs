using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class Person_BO
    {


        public List<PersonModel> SearchPerson(PersonModel in_person_o)
        {
            List<PersonModel> vl_personList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@Person_FirstName_s", Parameter_Value = in_person_o.Person_FirstName_s , SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_LastName_s", Parameter_Value = in_person_o.Person_LastName_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_Email_s", Parameter_Value = in_person_o.Person_Email_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_Portrait_s", Parameter_Value = in_person_o.Person_Portrait_s, SqlDbType = SqlDbType.VarChar },       
                new SQLParameterModel { Parameter_Name = "@Person_TelMobile_s", Parameter_Value = in_person_o.Person_TelMobile_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_TelHome_s", Parameter_Value = in_person_o.Person_TelHome_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_PersonStatus_ID_i", Parameter_Value = in_person_o.FK_PersonStatus_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_PersonRole_ID_i", Parameter_Value = in_person_o.FK_PersonRole_ID_i, SqlDbType = SqlDbType.Int }
            };

            vl_sqlcmd_o.SQL_Name = "Person_Search_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonModel), vl_sqlcmd_o).Cast<PersonModel>().ToList();

            return vl_personList_o;

        }

        public List<PersonModel> FindPerson(PersonModel in_person_o)
        {
            List<PersonModel> vl_personList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@Person_FirstName_s", Parameter_Value = in_person_o.Person_FirstName_s , SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_LastName_s", Parameter_Value = in_person_o.Person_LastName_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_Email_s", Parameter_Value = in_person_o.Person_Email_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_Portrait_s", Parameter_Value = in_person_o.Person_Portrait_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_TelMobile_s", Parameter_Value = in_person_o.Person_TelMobile_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_TelHome_s", Parameter_Value = in_person_o.Person_TelHome_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_PersonStatus_ID_i", Parameter_Value = in_person_o.FK_PersonStatus_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_PersonRole_ID_i", Parameter_Value = in_person_o.FK_PersonRole_ID_i, SqlDbType = SqlDbType.Int }
            };

            vl_sqlcmd_o.SQL_Name = "Person_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonModel), vl_sqlcmd_o).Cast<PersonModel>().ToList();

            return vl_personList_o;

        }

        public PersonModel GetPerson(Guid in_id_gu)
        {
            PersonModel vl_personModel_o = new PersonModel();
            List<PersonModel> vl_personList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Person_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Person_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonModel), vl_sqlcmd_o).Cast<PersonModel>().ToList();
            if (vl_personList_o.Count > 0)
            {
                vl_personModel_o = vl_personList_o.First();
            }

            return vl_personModel_o;

        }

        public bool UpdatePerson(PersonModel in_personModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Person_FirstName_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_LastName_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_Email_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_Portrait_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_TelMobile_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_TelHome_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_PersonStatus_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_PersonRole_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },


            };

            vl_sqlcmd_o.SQL_Name = "Person_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertPerson(PersonModel in_personModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Person_FirstName_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_LastName_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_Email_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_Portrait_s",  SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_TelMobile_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Person_TelHome_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_PersonStatus_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_PersonRole_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Person_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeletePerson(PersonModel in_personModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "Person_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }


        public List<PersonAddressModel> SearchPersonAddress(PersonAddressModel in_personAddress_o)
        {
            List<PersonAddressModel> vl_personAddressList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonAddress_ID_s", Parameter_Value = in_personAddress_o.PK_PersonAddress_ID_gu , SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", Parameter_Value = in_personAddress_o.FK_Person_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_PersonAddressType_ID_i", Parameter_Value = in_personAddress_o.FK_PersonAddressType_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Line1_s", Parameter_Value = in_personAddress_o.PersonAddress_Line1_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Line2_s", Parameter_Value = in_personAddress_o.PersonAddress_Line2_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Town_s", Parameter_Value = in_personAddress_o.PersonAddress_Town_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_County_s", Parameter_Value = in_personAddress_o.PersonAddress_County_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Postcode_s", Parameter_Value = in_personAddress_o.PersonAddress_Postcode_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Country_ID_i", Parameter_Value = in_personAddress_o.FK_Country_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_personAddress_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", Parameter_Value = in_personAddress_o.Created_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_personAddress_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_personAddress_o.Modified_d, SqlDbType = SqlDbType.DateTime }
            };

            vl_sqlcmd_o.SQL_Name = "PersonAddress_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personAddressList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonAddressModel), vl_sqlcmd_o).Cast<PersonAddressModel>().ToList();

            return vl_personAddressList_o;

        }


        public PersonModel GetPersonAddress(Guid in_id_gu)
        {
            PersonModel vl_personModel_o = new PersonModel();
            List<PersonModel> vl_personList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                 new SQLParameterModel { Parameter_Name = "@PK_PersonAddress_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "PersonAddress_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonModel), vl_sqlcmd_o).Cast<PersonModel>().ToList();
            if (vl_personList_o.Count > 0)
            {
                vl_personModel_o = vl_personList_o.First();
            }

            return vl_personModel_o;

        }

        public bool UpdatePersonAddress(PersonAddressModel in_personAddressModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonAddress_ID_s" , SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_PersonAddressType_ID_i",  SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Line1_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Line2_s",  SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Town_s",  SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_County_s",  SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Postcode_s",  SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Country_ID_i",  SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d",  SqlDbType = SqlDbType.DateTime }
            };

            vl_sqlcmd_o.SQL_Name = "PersonAddress_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personAddressModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertPersonAddress(PersonAddressModel in_personAddressModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonAddress_ID_s" , SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_PersonAddressType_ID_i",  SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Line1_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Line2_s",  SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Town_s",  SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_County_s",  SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonAddress_Postcode_s",  SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Country_ID_i",  SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s",  SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d",  SqlDbType = SqlDbType.DateTime },
            };

            vl_sqlcmd_o.SQL_Name = "PersonAddress_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personAddressModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }



        public List<PersonCourseModel> SearchPersonCourse(PersonCourseModel in_personCourse_o)
        {
            List<PersonCourseModel> vl_personCourseList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();

            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", Parameter_Value = in_personCourse_o.FK_Person_ID_gu , SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Course_ID_s", Parameter_Value = in_personCourse_o.FK_Course_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_PersonCourseStatus_ID_i", Parameter_Value = in_personCourse_o.FK_PersonCourseStatus_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@DateOfEnquiry_d", Parameter_Value = in_personCourse_o.DateOfEnquiry_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@DateOfEnrolment_d", Parameter_Value = in_personCourse_o.DateOfEnrolment_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_personCourse_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", Parameter_Value = in_personCourse_o.Created_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_personCourse_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_personCourse_o.Modified_d, SqlDbType = SqlDbType.DateTime }
            };

            vl_sqlcmd_o.SQL_Name = "PersonCourse_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personCourseList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonCourseModel), vl_sqlcmd_o).Cast<PersonCourseModel>().ToList();

            return vl_personCourseList_o;

        }


        public PersonCourseModel GetPersonCourse(Guid in_id_gu)
        {
            PersonCourseModel vl_personCourseModel_o = new PersonCourseModel();
            List<PersonCourseModel> vl_personCourseList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonCourse_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "PersonCourse_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personCourseList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonCourseModel), vl_sqlcmd_o).Cast<PersonCourseModel>().ToList();
            if (vl_personCourseList_o.Count > 0)
            {
                vl_personCourseModel_o = vl_personCourseList_o.First();
            }

            return vl_personCourseModel_o;

        }

        public bool UpdatePersonCourse(PersonCourseModel in_personCourseModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonCourse_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s",  SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Course_ID_s",  SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_PersonCourseStatus_ID_i",  SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@DateOfEnquiry_d",  SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@DateOfEnrolment_d",  SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s",  SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d",  SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s",  SqlDbType = SqlDbType.UniqueIdentifier }

            };

            vl_sqlcmd_o.SQL_Name = "PersonCourse_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personCourseModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertPersonCourse(PersonCourseModel in_personCourseModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonCourse_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s",  SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Course_ID_s",  SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_PersonCourseStatus_ID_i",  SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@DateOfEnquiry_d",  SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@DateOfEnrolment_d",  SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s",  SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d",  SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s",  SqlDbType = SqlDbType.UniqueIdentifier }
                
            };

            vl_sqlcmd_o.SQL_Name = "PersonCourse_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personCourseModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeletePersonCourse(PersonCourseModel in_personCourseModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonCourse_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "PersonCourse_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personCourseModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }



        public List<PersonEnquiryModel> SearchPersonEnquiry(PersonEnquiryModel in_personEnquiry_o)
        {
            List<PersonEnquiryModel> vl_personEnquiryList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", Parameter_Value = in_personEnquiry_o.FK_Person_ID_gu , SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiry_s", Parameter_Value = in_personEnquiry_o.PersonEnquiry_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiry_Ref_s", Parameter_Value = in_personEnquiry_o.PersonEnquiry_Ref_s, SqlDbType = SqlDbType.VarChar },        
                new SQLParameterModel { Parameter_Name = "@PersonEnquiry_Message_s", Parameter_Value = in_personEnquiry_o.PersonEnquiry_Message_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_PersonEnquiryStatus_ID_i", Parameter_Value = in_personEnquiry_o.FK_PersonEnquiryStatus_ID_i, SqlDbType = SqlDbType.Int },
            };

            vl_sqlcmd_o.SQL_Name = "PersonEnquiry_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personEnquiryList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonEnquiryModel), vl_sqlcmd_o).Cast<PersonEnquiryModel>().ToList();

            return vl_personEnquiryList_o;

        }


        public PersonEnquiryModel GetPersonEnquiry(Guid in_id_gu)
        {
            PersonEnquiryModel vl_personEnquiryModel_o = new PersonEnquiryModel();
            List<PersonEnquiryModel> vl_personEnquiryList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonEnquiry_ID_s", Parameter_Value = in_id_gu , SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "PersonEnquiry_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personEnquiryList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonEnquiryModel), vl_sqlcmd_o).Cast<PersonEnquiryModel>().ToList();
            if (vl_personEnquiryList_o.Count > 0)
            {
                vl_personEnquiryModel_o = vl_personEnquiryList_o.First();
            }

            return vl_personEnquiryModel_o;

        }

        public bool UpdatePersonEnquiry(PersonEnquiryModel in_personEnquiryModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonEnquiry_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiry_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiry_Message_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_PersonEnquiryStatus_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", SqlDbType = SqlDbType.DateTime },
            };

            vl_sqlcmd_o.SQL_Name = "PersonEnquiry_UPDATE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personEnquiryModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertPersonEnquiry(PersonEnquiryModel in_personEnquiryModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonEnquiry_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiry_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiry_Ref_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiry_Message_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_PersonEnquiryStatus_ID_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", SqlDbType = SqlDbType.DateTime },
            };

            vl_sqlcmd_o.SQL_Name = "PersonEnquiry_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personEnquiryModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeletePersonEnquiry(PersonEnquiryModel in_personEnquiryModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonEnquiry_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "PersonEnquiry_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personEnquiryModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }



        public List<PersonStatusModel> SearchPersonStatus(PersonStatusModel in_personStatus_o)
        {
            List<PersonStatusModel> vl_personStatusList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonStatus_ID_i", Parameter_Value = in_personStatus_o.PK_PersonStatus_ID_i , SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@PersonStatus_s", Parameter_Value = in_personStatus_o.PersonStatus_s, SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "PersonStatus_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personStatusList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonStatusModel), vl_sqlcmd_o).Cast<PersonStatusModel>().ToList();

            return vl_personStatusList_o;

        }

        public List<PersonRoleModel> SearchPersonRole(PersonRoleModel in_personRole_o)
        {
            List<PersonRoleModel> vl_personRoleList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonRole_ID_i", Parameter_Value = in_personRole_o.PK_PersonRole_ID_i , SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@PersonRole_s", Parameter_Value = in_personRole_o.PersonRole_s, SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "PersonRole_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personRoleList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonRoleModel), vl_sqlcmd_o).Cast<PersonRoleModel>().ToList();

            return vl_personRoleList_o;

        }

        public List<PersonCourseStatusModel> SearchPersonCourseStatus(PersonCourseStatusModel in_personCourseStatus_o)
        {
            List<PersonCourseStatusModel> vl_personCourseStatusList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonCourseStatus_ID_i", Parameter_Value = in_personCourseStatus_o.PK_PersonCourseStatus_ID_i , SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@PersonCourseStatus_s", Parameter_Value = in_personCourseStatus_o.PersonCourseStatus_s, SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "PersonCourseStatus_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personCourseStatusList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonCourseStatusModel), vl_sqlcmd_o).Cast<PersonCourseStatusModel>().ToList();

            return vl_personCourseStatusList_o;

        }

        public List<PersonEnquiryStatusModel> SearchPersonEnquiryStatus(PersonEnquiryStatusModel in_personEnquiryStatus_o)
        {
            List<PersonEnquiryStatusModel> vl_personEnquiryStatusList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonEnquiryStatus_ID_i", Parameter_Value = in_personEnquiryStatus_o.PK_PersonEnquiryStatus_ID_i , SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiryStatus_s", Parameter_Value = in_personEnquiryStatus_o.PersonEnquiryStatus_s, SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "PersonEnquiryStatus_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personEnquiryStatusList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonEnquiryStatusModel), vl_sqlcmd_o).Cast<PersonEnquiryStatusModel>().ToList();


            return vl_personEnquiryStatusList_o;

        }


        public List<PersonCommentModel> SearchPersonComment(PersonCommentModel in_personComment_o)
        {
            List<PersonCommentModel> vl_personCommentList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {

                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", Parameter_Value = in_personComment_o.FK_Person_ID_gu , SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@PersonComment_s", Parameter_Value = in_personComment_o.PersonComment_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_personComment_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", Parameter_Value = in_personComment_o.Created_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_personComment_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_personComment_o.Modified_d, SqlDbType = SqlDbType.DateTime },
            };

            vl_sqlcmd_o.SQL_Name = "PersonComment_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personCommentList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonCommentModel), vl_sqlcmd_o).Cast<PersonCommentModel>().ToList();

            return vl_personCommentList_o;

        }

        public bool InsertPersonComment(PersonCommentModel in_personCommentModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonComment_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@PersonComment_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d",  SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "PersonComment_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personCommentModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeletePersonComment(PersonCommentModel in_personCommentModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonComment_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "PersonComment_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personCommentModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }




        public List<PersonEnquiryCommunicationModel> SearchPersonEnquiryCommunication(PersonEnquiryCommunicationModel in_personEnquiryCommunication_o)
        {
            List<PersonEnquiryCommunicationModel> vl_personEnquiryCommunicationList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {

                new SQLParameterModel { Parameter_Name = "@FK_PersonEnquiry_ID_s", Parameter_Value = in_personEnquiryCommunication_o.FK_PersonEnquiry_ID_gu , SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiryCommunication_s", Parameter_Value = in_personEnquiryCommunication_o.PersonEnquiryCommunication_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", Parameter_Value = in_personEnquiryCommunication_o.FK_Person_Created_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d", Parameter_Value = in_personEnquiryCommunication_o.Created_d, SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Modified_ID_s", Parameter_Value = in_personEnquiryCommunication_o.FK_Person_Modified_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Modified_d", Parameter_Value = in_personEnquiryCommunication_o.Modified_d, SqlDbType = SqlDbType.DateTime },
            };

            vl_sqlcmd_o.SQL_Name = "PersonEnquiryCommunication_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_personEnquiryCommunicationList_o = vl_dataBinder_o.GetGenericModel(typeof(PersonEnquiryCommunicationModel), vl_sqlcmd_o).Cast<PersonEnquiryCommunicationModel>().ToList();

            return vl_personEnquiryCommunicationList_o;

        }

        public bool InsertPersonEnquiryCommunication(PersonEnquiryCommunicationModel in_personEnquiryCommunicationModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonEnquiryCommunication_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_PersonEnquiry_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@PersonEnquiryCommunication_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@EmailSent_b", SqlDbType = SqlDbType.Bit },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Created_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Created_d",  SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "PersonEnquiryCommunication_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personEnquiryCommunicationModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool DeletePersonEnquiryCommunication(PersonEnquiryCommunicationModel in_personEnquiryCommunicationModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonEnquiryCommunication_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_Current_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
            };

            vl_sqlcmd_o.SQL_Name = "PersonEnquiryCommunication_DELETE";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personEnquiryCommunicationModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }


        public bool InsertPersonLogin(PersonLoginModel in_personLoginModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonLogin_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Person_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@PersonLogin_Username_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonLogin_Login_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@PersonLogin_Success_b", SqlDbType = SqlDbType.Bit },
                new SQLParameterModel { Parameter_Name = "@PersonLogin_Logout_d", SqlDbType = SqlDbType.DateTime },
                new SQLParameterModel { Parameter_Name = "@PersonLogin_Browser_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonLogin_IP_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonLogin_BrowserDetails_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonLogin_Attempt_i", SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@PersonLogin_Impersonate_b", SqlDbType = SqlDbType.Bit },
            };

            vl_sqlcmd_o.SQL_Name = "PersonLogin_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personLoginModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }

        public bool InsertPersonSession(PersonSessionModel in_personSessionModel_o)
        {
            bool vl_success_z = false;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_PersonSession_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_PersonLogin_ID_s", SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@PersonSession_Controller_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonSession_Action_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonSession_Parameter_s", SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@PersonSession_Created_d", SqlDbType = SqlDbType.DateTime },
            };

            vl_sqlcmd_o.SQL_Name = "PersonSession_INSERT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_success_z = vl_dataBinder_o.InsertOrUpdateGenericModel(in_personSessionModel_o, vl_sqlcmd_o);

            return vl_success_z;
        }
    }
}