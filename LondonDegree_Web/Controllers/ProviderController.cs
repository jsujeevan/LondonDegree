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
    public class ProviderController : Controller
    {


        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Search(ProviderModel in_providerModel_o)
        {
            List<ProviderModel> vl_providerList_o = null;
            Provider_BO vl_provider_o = new Provider_BO();
            vl_providerList_o = vl_provider_o.SearchProvider(in_providerModel_o);
            return Json(vl_providerList_o);
        }

        public ActionResult AddNew()
        {
            ProviderModel vl_providerModel_o = new ProviderModel();
            List<CountryModel> vl_countryList_o = null;
            General_BO vl_general_o = new General_BO();
            vl_countryList_o = vl_general_o.SearchCountry(new CountryModel());
            ViewData["CountryList"] = vl_countryList_o;
            return View(vl_providerModel_o);
        }

        [HttpPost]
        public ActionResult AddNew(ProviderModel in_providerModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_inserted_z = false;
            Guid vl_provider_gu = Guid.Empty;
            Provider_BO vl_provider_o = new Provider_BO();
            Support_BO vl_support_o = new Support_BO();

            vl_validModel_z = ModelState.IsValid ? true : false;

            if (vl_validModel_z)
            {
                //Create provider
                vl_provider_gu = Guid.NewGuid();
                in_providerModel_o.PK_Provider_ID_gu = vl_provider_gu;
                in_providerModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_providerModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_inserted_z = vl_provider_o.InsertProvider(in_providerModel_o);

                //Redirect to provider page
                if (vl_inserted_z)
                {
                    return RedirectToAction("Index", "Provider", new { provider = vl_provider_gu });
                }
                else
                {
                    List<CountryModel> vl_countryList_o = null;
                    General_BO vl_general_o = new General_BO();
                    vl_countryList_o = vl_general_o.SearchCountry(new CountryModel());
                    ViewData["CountryList"] = vl_countryList_o;
                    return View(in_providerModel_o);
                }
            }
            else
            {
                List<CountryModel> vl_countryList_o = null;
                General_BO vl_general_o = new General_BO();
                vl_countryList_o = vl_general_o.SearchCountry(new CountryModel());
                ViewData["CountryList"] = vl_countryList_o;
                return View(in_providerModel_o);
            }


        }

        // GET: Provider
        public ActionResult Index(Guid provider)
        {
            ProviderModel vl_providerModel_o = new ProviderModel();
            List<CourseModel> vl_providerCourses_o = new List<CourseModel>();
            Provider_BO vl_provider_o = new Provider_BO();
            Course_BO vl_course_o = new Course_BO();
            //Get provider
            vl_providerModel_o = vl_provider_o.GetProvider(provider);
            //Get provider courses
            CourseModel vl_courseSearchModel_o = new CourseModel();
            vl_courseSearchModel_o.FK_Provider_ID_gu = provider;
            vl_providerCourses_o = vl_course_o.SearchCourse(vl_courseSearchModel_o);
            ViewData["CourseList"] = vl_providerCourses_o;
            return View(vl_providerModel_o);
        }


        
        public ActionResult EditProviderDetails(String modal, Guid id)
        {
            List<CountryModel> vl_countryList_o = null;
            Provider_BO vl_provider_o = new Provider_BO();
            General_BO vl_general_o = new General_BO();
            ProviderModel vl_ProviderModel_o = new ProviderModel();

            vl_countryList_o = vl_general_o.SearchCountry(new CountryModel());
            vl_ProviderModel_o = vl_provider_o.GetProvider(id);
            ViewData["CountryList"] = vl_countryList_o;
            ViewData["mainHeading"] = "Edit Provider Details";
            ViewData["modalDialog"] = modal;

            return View(vl_ProviderModel_o);
        }

        [HttpPost]
        public ActionResult EditProviderDetails(ProviderModel in_providerModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_updated_z = false;
            string vl_ErrorText_s = "";
            Guid vl_provider_gu = Guid.Empty;
            Provider_BO vl_provider_o = new Provider_BO();
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
                in_providerModel_o.FK_Person_Modified_ID_gu = vl_support_o.getCurrentUser();
                in_providerModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_updated_z = vl_provider_o.UpdateProvider(in_providerModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_providerModel_o.PK_Provider_ID_gu.ToString();
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

        
       public ActionResult AddNewProviderCourses(String modal, Guid id)
        {
            CourseModel vl_courseModel_o = new CourseModel();
            List<CourseLevelModel> vl_levelList_o = null;
            List<CourseCategoryModel> vl_categoryList_o = null;

            Provider_BO vl_provider_o = new Provider_BO();
            Course_BO vl_course_o = new Course_BO();
            vl_courseModel_o.FK_Provider_ID_gu = id;
            vl_categoryList_o = vl_course_o.SearchCourseCategory(new CourseCategoryModel());
            vl_levelList_o = vl_course_o.SearchCourseLevel(new CourseLevelModel());

            ViewData["CategoryList"] = vl_categoryList_o;
            ViewData["LevelList"] = vl_levelList_o;
            ViewData["mainHeading"] = "Add New Course";
            ViewData["modalDialog"] = modal;

            return View(vl_courseModel_o);
        }

        [HttpPost]
        public ActionResult AddNewProviderCourses(CourseModel in_courseModel_o)
        {
            Guid vl_courseID_gu = Guid.NewGuid();
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

                in_courseModel_o.PK_Course_ID_gu = vl_courseID_gu;
                in_courseModel_o.Course_Hidden_z = string.IsNullOrEmpty(vl_courseHidden_s) ? false : true;
                in_courseModel_o.Course_Provider_Hidden_z = string.IsNullOrEmpty(vl_providerHidden_s) ? false : true;

                in_courseModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_courseModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_courseUpdated_z = vl_course_o.InsertCourse(in_courseModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_courseModel_o.FK_Provider_ID_gu.ToString();
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