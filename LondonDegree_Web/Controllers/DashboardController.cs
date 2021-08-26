using LondonDegree_Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LondonDegree_Web.BO;
using LondonDegree_Web.Models;
using System.Net;

namespace LondonDegree_Web.Controllers
{
    [Authorize]
    [MonitorSession]
    [MonitorError]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            List<PersonEnquiryModel> vl_personEnquiryList_o = null;
            List<PersonCourseModel> vl_personCourseList_o = null;
            List<ObjectModel> vl_userObjectList_o = null;
            LinkedList<ObjectModel> vl_navigationMenu_o = null;
            PersonModel vl_personModel_o = null;

            Support_BO vl_support_o = new Support_BO();
            Person_BO vl_person_o = new Person_BO();
            Object_BO vl_object_o = new Object_BO();

            vl_personModel_o = vl_support_o.getCurrentUserObject();
            vl_personEnquiryList_o = vl_person_o.SearchPersonEnquiry(new PersonEnquiryModel());
            vl_personCourseList_o = vl_person_o.SearchPersonCourse(new PersonCourseModel());
            vl_userObjectList_o = vl_object_o.SearchObjectMenuItemsByRole(vl_personModel_o.FK_PersonRole_ID_i);
            vl_navigationMenu_o = vl_object_o.GetNavigationMenu(vl_userObjectList_o);

            ViewData["PersonModel"] = vl_personModel_o;
            ViewData["EnquiryList"] = vl_personEnquiryList_o;
            ViewData["CourseList"] = vl_personCourseList_o;
            ViewData["MenuList"] = vl_navigationMenu_o;
            return View();
        }

        // GET: Person
        public ActionResult MyProfileIndex()
        {
            PersonModel vl_personModel_o = null;
            List<PersonEnquiryModel> vl_enquiryList_o = null;
            List<PersonCourseModel> vl_courseList_o = null;
            List<PersonStatusModel> vl_statusList_o = null;
            List<PersonRoleModel> vl_roleList_o = null;
            List<PersonAddressModel> vl_personAddressList_o = null;
            List<PersonCommentModel> vl_personCommentList_o = null;
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();

            Guid person = vl_support_o.getCurrentUser();

            vl_personModel_o = vl_person_o.GetPerson(person);
            PersonCourseModel vl_courseSearchModel_o = new PersonCourseModel();
            vl_courseSearchModel_o.FK_Person_ID_gu = person;
            vl_courseList_o = vl_person_o.SearchPersonCourse(vl_courseSearchModel_o);

            PersonEnquiryModel vl_enquirySearchModel_o = new PersonEnquiryModel();
            vl_enquirySearchModel_o.FK_Person_ID_gu = person;
            vl_enquiryList_o = vl_person_o.SearchPersonEnquiry(vl_enquirySearchModel_o);

            PersonCommentModel vl_personCommentModel_o = new PersonCommentModel();
            vl_personCommentModel_o.FK_Person_ID_gu = person;
            vl_personCommentList_o = vl_person_o.SearchPersonComment(vl_personCommentModel_o);

            PersonAddressModel vl_PersonAddressModel_o = new PersonAddressModel();
            PersonAddressModel vl_PersonAddressSearchModel_o = new PersonAddressModel();
            vl_PersonAddressSearchModel_o.FK_Person_ID_gu = person;
            vl_PersonAddressSearchModel_o.FK_PersonAddressType_ID_i = 1;
            vl_personAddressList_o = vl_person_o.SearchPersonAddress(vl_PersonAddressSearchModel_o);
            if (vl_personAddressList_o.Count > 0)
            {
                vl_PersonAddressModel_o = vl_personAddressList_o.First();
            }

            vl_statusList_o = vl_person_o.SearchPersonStatus(new PersonStatusModel());
            vl_roleList_o = vl_person_o.SearchPersonRole(new PersonRoleModel());

            ViewData["PersonAddressModel"] = vl_PersonAddressModel_o;
            ViewData["CourseList"] = vl_courseList_o;
            ViewData["StatusList"] = vl_statusList_o;
            ViewData["RoleList"] = vl_roleList_o;
            ViewData["EnquiryList"] = vl_enquiryList_o;
            ViewData["CommentList"] = vl_personCommentList_o;

            return View(vl_personModel_o);
        }


        public ActionResult EditBasicDetails(String modal, Guid id)
        {
            List<PersonStatusModel> vl_statusList_o = null;
            List<PersonRoleModel> vl_roleList_o = null;
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();
            PersonModel vl_PersonModel_o = new PersonModel();
            PersonModel vl_CurrentUserModel_o = new PersonModel();

            vl_PersonModel_o = vl_person_o.GetPerson(id);
            vl_statusList_o = vl_person_o.SearchPersonStatus(new PersonStatusModel());
            vl_roleList_o = vl_person_o.SearchPersonRole(new PersonRoleModel());
            vl_CurrentUserModel_o = vl_support_o.getCurrentUserObject();

            ViewData["StatusList"] = vl_statusList_o;
            ViewData["RoleList"] = vl_roleList_o;
            ViewData["CurrentUser"] = vl_CurrentUserModel_o;

            ViewData["mainHeading"] = "Edit Basic Details";
            ViewData["modalDialog"] = modal;
            return View(vl_PersonModel_o);
        }

        [HttpPost]
        public ActionResult EditBasicDetails(PersonModel in_personModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_updateEmail_z = false;
            bool vl_accountCreated_z = false;
            string vl_ErrorText_s = "";
            Guid vl_person_gu = Guid.Empty;
            PersonModel vl_personModel_o = new PersonModel();
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();
            PersonModel vl_tempModel_o = new PersonModel();

            vl_validModel_z = ModelState.IsValid ? true : false;

            if (vl_validModel_z)
            {
                vl_tempModel_o = vl_person_o.GetPerson(in_personModel_o.PK_Person_ID_gu);
                if (!vl_tempModel_o.Person_Email_s.Equals(in_personModel_o.Person_Email_s))
                {
                    PersonModel vl_newModel_o = new PersonModel();
                    vl_newModel_o.Person_Email_s = in_personModel_o.Person_Email_s;
                    List<PersonModel> vl_searchList_o = vl_person_o.FindPerson(vl_newModel_o);
                    if (vl_searchList_o.Count > 0)
                    {
                        // Email already in use, add model error to invalidate the model
                        ModelState.AddModelError("Person_Email_s", "The email address is already exists");
                        vl_validModel_z = false;
                    }
                    else
                    {
                        vl_updateEmail_z = true;
                    }
                }

            }

            if (!vl_validModel_z)
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        vl_ErrorText_s += error.ErrorMessage + "<br />";
                    }
                }
            }


            if (vl_validModel_z)
            {
                //Update person
                in_personModel_o.FK_Person_Modified_ID_gu = vl_support_o.getCurrentUser();
                in_personModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                //Create account
                vl_accountCreated_z = vl_person_o.UpdatePerson(in_personModel_o);
                if (vl_accountCreated_z & vl_updateEmail_z)
                {
                    Account_BO vl_account_o = new Account_BO();
                    AspNetUsersModel vl_aspNetUser_o = new AspNetUsersModel();
                    vl_aspNetUser_o.Email = vl_tempModel_o.Person_Email_s;
                    vl_aspNetUser_o.UserName = vl_tempModel_o.Person_Email_s;
                    List<AspNetUsersModel> vl_accountList_o = new List<AspNetUsersModel>();
                    vl_accountList_o = vl_account_o.SearchAspNetUsers(vl_aspNetUser_o);
                    if (vl_accountList_o.Count == 1)
                    {
                        AspNetUsersModel vl_aspNetUpdatedUser_o = new AspNetUsersModel();
                        vl_aspNetUpdatedUser_o.Id = vl_accountList_o.First().Id;
                        vl_aspNetUpdatedUser_o.Email = in_personModel_o.Person_Email_s;
                        vl_aspNetUpdatedUser_o.UserName = in_personModel_o.Person_Email_s;
                        vl_account_o.UpdateAspNetUsers(vl_aspNetUpdatedUser_o);
                    }
                }
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_personModel_o.PK_Person_ID_gu.ToString();
                return vl_Return_o;
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.SeeOther;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = vl_ErrorText_s;
                return vl_Return_o;
            }


        }




        public ActionResult EditAddressDetails(String modal, Guid id)
        {
            List<PersonAddressModel> vl_personAddressList_o = null;
            List<CountryModel> vl_countryList_o = null;
            Person_BO vl_person_o = new Person_BO();
            General_BO vl_general_o = new General_BO();
            PersonAddressModel vl_PersonAddressModel_o = new PersonAddressModel();
            PersonAddressModel vl_PersonAddressSearchModel_o = new PersonAddressModel();
            vl_PersonAddressSearchModel_o.FK_Person_ID_gu = id;
            vl_PersonAddressSearchModel_o.FK_PersonAddressType_ID_i = 1;
            vl_personAddressList_o = vl_person_o.SearchPersonAddress(vl_PersonAddressSearchModel_o);
            if (vl_personAddressList_o.Count > 0)
            {
                vl_PersonAddressModel_o = vl_personAddressList_o.First();
            }

            vl_countryList_o = vl_general_o.SearchCountry(new CountryModel());
            ViewData["CountryList"] = vl_countryList_o;
            ViewData["mainHeading"] = "Edit Address Details";
            ViewData["modalDialog"] = modal;
            return View(vl_PersonAddressModel_o);
        }

        [HttpPost]
        public ActionResult EditAddressDetails(PersonAddressModel in_personAddressModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_addressUpdated_z = false;
            string vl_ErrorText_s = "";
            Guid vl_person_gu = Guid.Empty;
            PersonModel vl_personModel_o = new PersonModel();
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();
            PersonModel vl_tempModel_o = new PersonModel();

            vl_validModel_z = ModelState.IsValid ? true : false;

            if (!vl_validModel_z)
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        vl_ErrorText_s += error.ErrorMessage + "<br />";
                    }
                }
            }


            if (vl_validModel_z)
            {
                in_personAddressModel_o.FK_Person_Modified_ID_gu = vl_support_o.getCurrentUser();
                in_personAddressModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_addressUpdated_z = vl_person_o.UpdatePersonAddress(in_personAddressModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_personAddressModel_o.FK_Person_ID_gu.ToString();
                return vl_Return_o;
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.SeeOther;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = vl_ErrorText_s;
                return vl_Return_o;
            }


        }

    }
}