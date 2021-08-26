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
    public class CourseController : Controller
    {

        public ActionResult Search()
        {
            List<CourseCategoryModel> vl_categoryList_o = null;
            List<CourseLevelModel> vl_levelList_o = null;
            List<ProviderModel> vl_providerList_o = null;
            Course_BO vl_course_o = new Course_BO();
            Provider_BO vl_provider_o = new Provider_BO();
            vl_categoryList_o = vl_course_o.SearchCourseCategory(new CourseCategoryModel());
            vl_levelList_o = vl_course_o.SearchCourseLevel(new CourseLevelModel());
            vl_providerList_o = vl_provider_o.SearchProvider(new ProviderModel());
            ViewData["CategoryList"] = vl_categoryList_o;
            ViewData["LevelList"] = vl_levelList_o;
            ViewData["ProviderList"] = vl_providerList_o;
            return View();
        }

        [HttpPost]
        public JsonResult Search(CourseModel in_courseModel_o)
        {
            List<CourseModel> vl_courseList_o = null;
            Course_BO vl_course_o = new Course_BO();
            vl_courseList_o = vl_course_o.SearchCourse(in_courseModel_o);
            return Json(vl_courseList_o);
        }

        // GET: Course
        public ActionResult Index(Guid course)
        {
            CourseModel vl_courseModel_o = null;
            PersonCourseModel vl_personCourseSearchModel_o = new PersonCourseModel();
            List<PersonCourseModel> vl_personList_o = new List<PersonCourseModel>();

            Course_BO vl_course_o = new Course_BO();
            Person_BO vl_person_o = new Person_BO();
            vl_courseModel_o = vl_course_o.GetCourse(course);

            vl_personCourseSearchModel_o.FK_Course_ID_gu = course;
            vl_personList_o = vl_person_o.SearchPersonCourse(vl_personCourseSearchModel_o);
            ViewData["PersonList"] = vl_personList_o;
            return View(vl_courseModel_o);
        }

        
        public ActionResult EditCourseDetails(String modal, Guid id)
        {
            CourseModel vl_courseModel_o = null;
            List<CourseLevelModel> vl_levelList_o = null;
            List<ProviderModel> vl_providerList_o = null;
            List<CourseCategoryModel> vl_categoryList_o = null;

            Provider_BO vl_provider_o = new Provider_BO();
            Course_BO vl_course_o = new Course_BO();
            vl_courseModel_o = vl_course_o.GetCourse(id);
            vl_categoryList_o = vl_course_o.SearchCourseCategory(new CourseCategoryModel());
            vl_levelList_o = vl_course_o.SearchCourseLevel(new CourseLevelModel());
            vl_providerList_o = vl_provider_o.SearchProvider(new ProviderModel());

            ViewData["CategoryList"] = vl_categoryList_o;
            ViewData["LevelList"] = vl_levelList_o;
            ViewData["ProviderList"] = vl_providerList_o;
            ViewData["mainHeading"] = "Edit Basic Details";
            ViewData["modalDialog"] = modal;

            return View(vl_courseModel_o);
        }

        [HttpPost]
        public ActionResult EditCourseDetails(CourseModel in_courseModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_courseUpdated_z = false;
            string vl_ErrorText_s = "";
            Course_BO vl_course_o = new Course_BO();
            Support_BO vl_support_o = new Support_BO();

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
                string vl_courseHidden_s = "";
                string vl_providerHidden_s = "";
                vl_courseHidden_s = Request["Course_Hidden_Check_s"];
                vl_providerHidden_s = Request["Course_Provider_Check_s"];

                in_courseModel_o.Course_Hidden_z =  string.IsNullOrEmpty(vl_courseHidden_s) ? false : true;
                in_courseModel_o.Course_Provider_Hidden_z = string.IsNullOrEmpty(vl_providerHidden_s) ? false : true;

                in_courseModel_o.FK_Person_Modified_ID_gu = vl_support_o.getCurrentUser();
                in_courseModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_courseUpdated_z = vl_course_o.UpdateCourse(in_courseModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_courseModel_o.PK_Course_ID_gu.ToString();
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

        
        public ActionResult DeleteCourse(Guid course)
        {
            CourseModel vl_CourseModel_o = new CourseModel();
            Course_BO vl_course_o = new Course_BO();
            Support_BO vl_support_o = new Support_BO();

            vl_CourseModel_o = vl_course_o.GetCourse(course);
            vl_CourseModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
            vl_course_o.DeleteCourse(vl_CourseModel_o);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ContentResult vl_Return_o = new ContentResult();
            vl_Return_o.Content = vl_CourseModel_o.FK_Provider_ID_gu.ToString();
            return vl_Return_o;
        }

        public ActionResult AddNewCoursePerson(String modal, Guid id)
        {
            PersonCourseModel vl_personCourseModel_o = new PersonCourseModel();
            List<PersonModel> vl_personList_o = null;
            List<PersonCourseStatusModel> vl_personCourseStatusList_o = null;
            List<PersonCourseModel> vl_personCourseList_o = null;

            Person_BO vl_person_o = new Person_BO();
            Course_BO vl_course_o = new Course_BO();
            vl_personCourseModel_o.FK_Course_ID_gu = id;
            vl_personList_o = vl_person_o.SearchPerson(new PersonModel());
            vl_personCourseStatusList_o = vl_person_o.SearchPersonCourseStatus(new PersonCourseStatusModel());

            vl_personCourseList_o = vl_person_o.SearchPersonCourse(vl_personCourseModel_o);

            ViewData["PersonCourseStatusList"] = vl_personCourseStatusList_o;
            ViewData["PersonCourseList"] = vl_personCourseList_o;
            ViewData["PersonList"] = vl_personList_o;
            ViewData["mainHeading"] = "Add New Course";
            ViewData["modalDialog"] = modal;

            return View(vl_personCourseModel_o);
        }

        [HttpPost]
        public ActionResult AddNewCoursePerson(PersonCourseModel in_personCourseModel_o)
        {
            Guid vl_personCourseID_gu = Guid.NewGuid();
            bool vl_validModel_z = false;
            bool vl_personCourseInserted_z = false;
            string vl_ErrorText_s = "";
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();

            //Clear and include model errors
            ModelState["DateOfEnrolment_d"].Errors.Clear();
            if (in_personCourseModel_o.FK_Person_ID_gu == Guid.Empty)
            {
                ModelState.AddModelError("FK_Person_ID_gu", "Please select a person");
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
                vl_Return_o.Content = in_personCourseModel_o.FK_Course_ID_gu.ToString();
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


        public ActionResult EditCoursePerson(String modal, Guid id)
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
        public ActionResult EditCoursePerson(PersonCourseModel in_personCourseModel_o)
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
                in_personCourseModel_o.FK_Person_Modified_ID_gu = vl_support_o.getCurrentUser();
                in_personCourseModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_personCourseInserted_z = vl_person_o.UpdatePersonCourse(in_personCourseModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_personCourseModel_o.FK_Course_ID_gu.ToString();
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

        public ActionResult DeleteCoursePerson(Guid personcourse)
        {
            PersonCourseModel vl_personCourseModel_o = new PersonCourseModel();
            Person_BO vl_person_o = new Person_BO();

            vl_personCourseModel_o = vl_person_o.GetPersonCourse(personcourse);
            vl_person_o.DeletePersonCourse(vl_personCourseModel_o);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ContentResult vl_Return_o = new ContentResult();
            vl_Return_o.Content = vl_personCourseModel_o.FK_Course_ID_gu.ToString();
            return vl_Return_o;
        }

    }
}