using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LondonDegree_Web.Models;
using LondonDegree_Web.BO;
using System.Net;
using LondonDegree_Web.Helpers;

namespace LondonDegree_Web.Controllers
{
    [Authorize]
    [MonitorSession]
    [MonitorError]
    public class PersonController : Controller
    {

        public ActionResult Search()
        {
            List<PersonStatusModel> vl_statusList_o = null;
            List<PersonRoleModel> vl_roleList_o = null;
            Person_BO vl_person_o = new Person_BO();
            vl_statusList_o = vl_person_o.SearchPersonStatus(new PersonStatusModel());
            vl_roleList_o = vl_person_o.SearchPersonRole(new PersonRoleModel());
            ViewData["StatusList"] = vl_statusList_o;
            ViewData["RoleList"] = vl_roleList_o;
            return View();
        }

        [HttpPost]
        public JsonResult Search(PersonModel in_personModel_o)
        {
            List<PersonModel> vl_personList_o = null;
            Person_BO vl_person_o = new Person_BO();
            vl_personList_o = vl_person_o.SearchPerson(in_personModel_o);
            return Json(vl_personList_o);
        }
        public ActionResult AddNew()
        {
            PersonModel vl_personModel_o = new PersonModel();
            List<PersonStatusModel> vl_statusList_o = null;
            List<PersonRoleModel> vl_roleList_o = null;
            Person_BO vl_person_o = new Person_BO();
            vl_statusList_o = vl_person_o.SearchPersonStatus(new PersonStatusModel());
            vl_roleList_o = vl_person_o.SearchPersonRole(new PersonRoleModel());
            ViewData["StatusList"] = vl_statusList_o;
            ViewData["RoleList"] = vl_roleList_o;
            return View(vl_personModel_o);
        }

        [HttpPost]
        //[MonitorErrorServer]
        public ActionResult AddNew(PersonModel in_personModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_accountCreated_z = false;
            bool vl_addressCreated_z = false;
            Guid vl_person_gu = Guid.Empty;
            PersonModel vl_personModel_o = new PersonModel();
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();

            vl_validModel_z = ModelState.IsValid ? true : false;

            // Check for email exists
            if (vl_validModel_z)
            {
                PersonModel vl_searchModel_o = new PersonModel();
                vl_searchModel_o.Person_Email_s = in_personModel_o.Person_Email_s.Trim();
                List<PersonModel> vl_searchList_o = vl_person_o.FindPerson(vl_searchModel_o);
                if (vl_searchList_o.Count > 0)
                {
                    // Email already in use, add model error to invalidate the model
                    ModelState.AddModelError("Person_Email_s", "The email address is already exists");
                    vl_validModel_z = false;
                }

            }

            if (vl_validModel_z)
            {
                //Create person
                vl_person_gu = Guid.NewGuid();
                in_personModel_o.PK_Person_ID_gu = vl_person_gu;
                in_personModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_personModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                //Create account
                vl_accountCreated_z = vl_person_o.InsertPerson(in_personModel_o);
                //Insert Address
                PersonAddressModel vl_personAddress_o = new PersonAddressModel();
                vl_personAddress_o.PK_PersonAddress_ID_gu = Guid.NewGuid();
                vl_personAddress_o.FK_Person_ID_gu = vl_person_gu;
                vl_personAddress_o.FK_PersonAddressType_ID_i = 1;
                vl_personAddress_o.Created_d = DateTime.Now;
                vl_personAddress_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                vl_addressCreated_z = vl_person_o.InsertPersonAddress(vl_personAddress_o);
                //Redirect to person page
                if (vl_accountCreated_z)
                {
                    return RedirectToAction("Index", "Person", new { person = vl_person_gu });
                }
                else
                {
                    List<PersonStatusModel> vl_statusList_o = null;
                    List<PersonRoleModel> vl_roleList_o = null;
                    vl_statusList_o = vl_person_o.SearchPersonStatus(new PersonStatusModel());
                    vl_roleList_o = vl_person_o.SearchPersonRole(new PersonRoleModel());
                    ViewData["StatusList"] = vl_statusList_o;
                    ViewData["RoleList"] = vl_roleList_o;
                    return View(in_personModel_o);
                }
            }
            else
            {
                List<PersonStatusModel> vl_statusList_o = null;
                List<PersonRoleModel> vl_roleList_o = null;
                vl_statusList_o = vl_person_o.SearchPersonStatus(new PersonStatusModel());
                vl_roleList_o = vl_person_o.SearchPersonRole(new PersonRoleModel());
                ViewData["StatusList"] = vl_statusList_o;
                ViewData["RoleList"] = vl_roleList_o;
                return View(in_personModel_o);
            }


        }

        // GET: Person
        public ActionResult Index(Guid person)
        {
            PersonModel vl_personModel_o = null;
            List<PersonEnquiryModel> vl_enquiryList_o = null;
            List<PersonCourseModel> vl_courseList_o = null;
            List<PersonStatusModel> vl_statusList_o = null;
            List<PersonRoleModel> vl_roleList_o = null;
            List<PersonAddressModel> vl_personAddressList_o = null;
            List<PersonCommentModel> vl_personCommentList_o = null;
            Person_BO vl_person_o = new Person_BO();

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
            PersonModel vl_PersonModel_o = new PersonModel();

            vl_PersonModel_o = vl_person_o.GetPerson(id);
            vl_statusList_o = vl_person_o.SearchPersonStatus(new PersonStatusModel());
            vl_roleList_o = vl_person_o.SearchPersonRole(new PersonRoleModel());
            ViewData["StatusList"] = vl_statusList_o;
            ViewData["RoleList"] = vl_roleList_o;

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
            if (vl_personAddressList_o.Count > 0) {
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


        
       public ActionResult AddNewPersonCourses(String modal, Guid id)
        {
            PersonCourseModel vl_personCourseModel_o = new PersonCourseModel();
            List<CourseModel> vl_courseList_o = null;
            List<PersonCourseStatusModel> vl_personCourseStatusList_o = null;
            List<PersonCourseModel> vl_personCourseList_o = null;

            Person_BO vl_person_o = new Person_BO();
            Course_BO vl_course_o = new Course_BO();
            vl_personCourseModel_o.FK_Person_ID_gu = id;
            vl_courseList_o = vl_course_o.SearchCourse(new CourseModel());
            vl_personCourseStatusList_o = vl_person_o.SearchPersonCourseStatus(new PersonCourseStatusModel());

            vl_personCourseList_o = vl_person_o.SearchPersonCourse(vl_personCourseModel_o);

            ViewData["PersonCourseStatusList"] = vl_personCourseStatusList_o;
            ViewData["PersonCourseList"] = vl_personCourseList_o;
            ViewData["CourseList"] = vl_courseList_o;
            ViewData["mainHeading"] = "Add New Course";
            ViewData["modalDialog"] = modal;

            return View(vl_personCourseModel_o);
        }

        [HttpPost]
        public ActionResult AddNewPersonCourses(PersonCourseModel in_personCourseModel_o)
        {
            Guid vl_personCourseID_gu = Guid.NewGuid();
            bool vl_validModel_z = false;
            bool vl_personCourseInserted_z = false;
            string vl_ErrorText_s = "";
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();

            //Clear and include model errors
            ModelState["DateOfEnrolment_d"].Errors.Clear();
            if (in_personCourseModel_o.FK_Course_ID_gu == Guid.Empty)
            {
                ModelState.AddModelError("FK_Course_ID_gu", "Please select a course");
                vl_validModel_z = false;
            }
            //Validate model
            vl_validModel_z = ModelState.IsValid ? true : false;
            //check business rules
            if (vl_validModel_z)
            {
                if (in_personCourseModel_o.DateOfEnrolment_d != new DateTime())
                {
                    if (in_personCourseModel_o.DateOfEnrolment_d < in_personCourseModel_o.DateOfEnquiry_d)
                    {
                        ModelState.AddModelError("DateOfEnrolment_d", "Date of enquiry is lesser than the date of enrolement");
                        vl_validModel_z = false;
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
                in_personCourseModel_o.PK_PersonCourse_ID_gu = vl_personCourseID_gu;
                in_personCourseModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_personCourseModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_personCourseInserted_z = vl_person_o.InsertPersonCourse(in_personCourseModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_personCourseModel_o.FK_Person_ID_gu.ToString();
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


        public ActionResult EditPersonCourses(String modal, Guid id)
        {
            PersonCourseModel vl_personCourseModel_o = new PersonCourseModel();
            List<PersonCourseStatusModel> vl_personCourseStatusList_o = null;

            Person_BO vl_person_o = new Person_BO();
            Course_BO vl_course_o = new Course_BO();
 
            vl_personCourseModel_o = vl_person_o.GetPersonCourse(id);
            vl_personCourseStatusList_o = vl_person_o.SearchPersonCourseStatus(new PersonCourseStatusModel());

            ViewData["PersonCourseStatusList"] = vl_personCourseStatusList_o;
            ViewData["mainHeading"] = "Edit Course";
            ViewData["modalDialog"] = modal;

            return View(vl_personCourseModel_o);
        }

        [HttpPost]
        public ActionResult EditPersonCourses(PersonCourseModel in_personCourseModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_personCourseInserted_z = false;
            string vl_ErrorText_s = "";
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();

            //Clear and include model errors
            ModelState["DateOfEnrolment_d"].Errors.Clear();
            //Validate model
            vl_validModel_z = ModelState.IsValid ? true : false;
            //check business rules
            if (vl_validModel_z)
            {
                if (in_personCourseModel_o.DateOfEnrolment_d != new DateTime())
                {
                    if (in_personCourseModel_o.DateOfEnrolment_d < in_personCourseModel_o.DateOfEnquiry_d)
                    {
                        ModelState.AddModelError("DateOfEnrolment_d", "Date of enquiry is lesser than the date of enrolement");
                        vl_validModel_z = false;
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
                in_personCourseModel_o.FK_Person_Modified_ID_gu= vl_support_o.getCurrentUser();
                in_personCourseModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_personCourseInserted_z = vl_person_o.UpdatePersonCourse(in_personCourseModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_personCourseModel_o.FK_Person_ID_gu.ToString();
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

        public ActionResult DeletePersonCourses(Guid personcourse)
        {
            PersonCourseModel vl_personCourseModel_o = new PersonCourseModel();
            Person_BO vl_person_o = new Person_BO();

            vl_personCourseModel_o = vl_person_o.GetPersonCourse(personcourse);
            vl_person_o.DeletePersonCourse(vl_personCourseModel_o);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ContentResult vl_Return_o = new ContentResult();
            vl_Return_o.Content = vl_personCourseModel_o.FK_Person_ID_gu.ToString();
            return vl_Return_o;
        }

        
        [HttpPost]
        public ActionResult AddNewComment(PersonCommentModel in_personCommentModel_o)
        {
            Guid vl_personCommentID_gu = Guid.NewGuid();
            bool vl_validModel_z = false;
            bool vl_Inserted_z = false;
            string vl_ErrorText_s = "";
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();
            //Validate model
            vl_validModel_z = ModelState.IsValid ? true : false;


            if (vl_validModel_z)
            {
                in_personCommentModel_o.PK_PersonComment_ID_gu = vl_personCommentID_gu;
                in_personCommentModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_personCommentModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_Inserted_z = vl_person_o.InsertPersonComment(in_personCommentModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_personCommentModel_o.FK_Person_ID_gu.ToString();
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