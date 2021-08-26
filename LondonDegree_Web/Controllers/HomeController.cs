using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LondonDegree_Web.Models;
using LondonDegree_Web.BO;
using LondonDegree_Web.Helpers;

namespace LondonDegree_Web.Controllers
{
    [MonitorError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Event_BO vl_event_o = new Event_BO();
            List<NewsModel> vl_newsList_o = null;
            List<EventModel> vl_eventList_o = null;
            vl_newsList_o = vl_event_o.SearchNews(new NewsSearchModel());
            vl_eventList_o = vl_event_o.SearchEvent(new EventSearchModel());
            ViewData["NewsList"] = vl_newsList_o;
            ViewData["EventList"] = vl_eventList_o;
            return View();
        }
        
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error(Guid error)
        {
            ErrorModel vl_error_o = new ErrorModel();
            vl_error_o.Reference = error;
            return View(vl_error_o);
            
        }


        public ActionResult Index_Aboutus()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index_Contactus()
        {
            ContactUsModel vl_contactus_o = new ContactUsModel();
            return View(vl_contactus_o);
        }

        [HttpPost]
        //[MonitorErrorServer]
        public ActionResult Index_Contactus(ContactUsModel in_enquiry_o)
        {
            string vl_email_s = "";
            bool vl_validModel_z = false;
            bool vl_accountCreated_z = false;
            bool vl_addressCreated_z = false;
            bool vl_accountExist_z = false;
            Guid vl_existingPerson_gu = Guid.Empty;
            Guid vl_newPerson_gu = Guid.Empty;
            Guid vl_personEnquiry_gu = Guid.NewGuid();

            string vl_template_s = "";
            string vl_message_s = "";
            string vl_tempMessage_s = "";
            string vl_subject_s = "";
            Guid vl_systemUser_gu = Guid.Empty;
            EmailTemplateModel vl_emailTemplateModel_o = null;

            PersonModel vl_tempPersonModel_o = new PersonModel();
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();
            Email_BO vl_email_o = new Email_BO();

            vl_validModel_z = ModelState.IsValid ? true : false;

            if (vl_validModel_z)
            {

                PersonModel vl_searchModel_o = new PersonModel();
                vl_email_s = in_enquiry_o.Person_Email_s.Trim();
                vl_searchModel_o.Person_Email_s = vl_email_s;
                List<PersonModel> vl_searchList_o = vl_person_o.FindPerson(vl_searchModel_o);
                if (vl_searchList_o.Count > 0)
                {
                    vl_accountExist_z = true;
                    vl_existingPerson_gu = vl_searchList_o.First().PK_Person_ID_gu;
                }

                if (!vl_accountExist_z)
                {
                    //Create person
                    vl_newPerson_gu = Guid.NewGuid();
                    PersonModel in_personModel_o = new PersonModel();
                    in_personModel_o.PK_Person_ID_gu = vl_newPerson_gu;
                    in_personModel_o.Person_FirstName_s = in_enquiry_o.Person_FirstName_s;
                    in_personModel_o.Person_LastName_s = in_enquiry_o.Person_LastName_s;
                    in_personModel_o.Person_Email_s = vl_email_s;
                    in_personModel_o.Person_TelMobile_s = in_enquiry_o.Person_TelMobile_s;
                    in_personModel_o.FK_PersonRole_ID_i = 3;
                    in_personModel_o.FK_PersonStatus_ID_i = 1;
                    in_personModel_o.FK_Person_Created_ID_gu = vl_support_o.getSystemUser();
                    in_personModel_o.FK_Person_Current_ID_s = vl_support_o.getSystemUser();
                    //Create account
                    vl_accountCreated_z = vl_person_o.InsertPerson(in_personModel_o);
                    //Insert Address
                    PersonAddressModel vl_personAddress_o = new PersonAddressModel();
                    vl_personAddress_o.PK_PersonAddress_ID_gu = Guid.NewGuid();
                    vl_personAddress_o.FK_Person_ID_gu = vl_newPerson_gu;
                    vl_personAddress_o.FK_PersonAddressType_ID_i = 1;
                    vl_personAddress_o.Created_d = DateTime.Now;
                    vl_personAddress_o.FK_Person_Created_ID_gu = vl_support_o.getSystemUser();
                    vl_addressCreated_z = vl_person_o.InsertPersonAddress(vl_personAddress_o);
                }

                //Add enquiry
                PersonEnquiryModel in_personEnquiryModel_o = new PersonEnquiryModel();
                in_personEnquiryModel_o.PK_PersonEnquiry_ID_gu = vl_personEnquiry_gu;
                string vl_enquiryRef_s = vl_personEnquiry_gu.ToString().Substring(0, 3) + vl_personEnquiry_gu.ToString().Substring(vl_personEnquiry_gu.ToString().Length - 2);
                in_personEnquiryModel_o.FK_Person_ID_gu = vl_accountExist_z ? vl_existingPerson_gu : vl_newPerson_gu;
                in_personEnquiryModel_o.PersonEnquiry_s = in_enquiry_o.Subject_s;
                in_personEnquiryModel_o.PersonEnquiry_Ref_s = vl_enquiryRef_s.ToUpper();
                in_personEnquiryModel_o.PersonEnquiry_Message_s = in_enquiry_o.Message_s;
                in_personEnquiryModel_o.FK_PersonEnquiryStatus_ID_i = 1;
                in_personEnquiryModel_o.FK_Person_Created_ID_gu = vl_support_o.getSystemUser();
                in_personEnquiryModel_o.FK_Person_Current_ID_s = vl_support_o.getSystemUser();
                bool vl_enquiryCreated_z = vl_person_o.InsertPersonEnquiry(in_personEnquiryModel_o);

                //Redirect to person page
                if (vl_enquiryCreated_z)
                {
                    vl_tempPersonModel_o = vl_person_o.GetPerson(in_personEnquiryModel_o.FK_Person_ID_gu);

                    vl_template_s = System.Configuration.ConfigurationManager.AppSettings["Enquiry"];
                    vl_systemUser_gu = vl_support_o.getSystemUser();

                    //Get email template
                    vl_emailTemplateModel_o = vl_email_o.GetEmailTemplate(new Guid(vl_template_s));

                    vl_subject_s = "LondonDegree.co.uk - Enquiry Submitted - Ref " + in_personEnquiryModel_o.PersonEnquiry_Ref_s;
                    vl_message_s = vl_emailTemplateModel_o.EmailTemplate_Message_s;
                    vl_message_s = vl_message_s.Replace("[@FirstnameLabel]", vl_tempPersonModel_o.Person_FirstName_s);
                    vl_tempMessage_s = "Your enquiry is now submitted and your unique reference number is " + in_personEnquiryModel_o.PersonEnquiry_Ref_s + ".<br> We aim to resolve your query within two working days but feel free to contact us if your request is urgent.";
                    vl_message_s = vl_message_s.Replace("[@Message]", vl_tempMessage_s);

                    EmailModel vl_emailModel_o = new EmailModel();
                    vl_emailModel_o.PK_Email_ID_gu = Guid.NewGuid();
                    vl_emailModel_o.Email_Subject_s = vl_subject_s;
                    vl_emailModel_o.Email_Message_s = vl_message_s;
                    vl_emailModel_o.FK_Person_From_ID_gu = vl_systemUser_gu;
                    vl_emailModel_o.FK_Person_To_ID_gu = vl_tempPersonModel_o.PK_Person_ID_gu;
                    vl_emailModel_o.Person_To_Email_s = vl_tempPersonModel_o.Person_Email_s;
                    vl_emailModel_o.Email_Sent_d = DateTime.Now;

                    SendGrid_API vl_sendGrid_o = new SendGrid_API();
                    string vl_status_s = vl_sendGrid_o.SendEmail(vl_emailModel_o);
                    vl_emailModel_o.Email_Success_z = true;

                    vl_email_o.InsertEmail(vl_emailModel_o);

                    ContactUsModel vl_contactus_o = new ContactUsModel();
                    ViewData["Message"] = "Your enquiry is now submitted and your unique reference number is "+ in_personEnquiryModel_o.PersonEnquiry_Ref_s + ". One of our support representative will be in contact with you as soon as possible.!";
                    return View(vl_contactus_o);
                }
                else
                {
                    return View(in_enquiry_o);
                }
            }
            else
            {
                return View(in_enquiry_o);
            }


        }

        public ActionResult Index_Services()
        {
            CMS_BO vl_cms_o = new CMS_BO();
            List<ServiceModel> vl_serviceList_o = new List<ServiceModel>();
            vl_serviceList_o = vl_cms_o.SearchService(new ServiceModel());
            ViewData["ServiceList"] = vl_serviceList_o;
            return View();
        }

        public ActionResult Index_Service(Guid service)
        {
            ServiceModel vl_serviceModel_o = new ServiceModel();
            CMS_BO vl_cms_o = new CMS_BO();
            vl_serviceModel_o = vl_cms_o.GetService(service);
            return View(vl_serviceModel_o);
        }

        public ActionResult Index_Courses_ByCategory()
        {
            List<CourseModel> vl_courseList_o = new List<CourseModel>();
            Course_BO vl_course_o = new Course_BO();
            vl_courseList_o = vl_course_o.SearchCourse(new CourseModel());
            ViewData["CourseList"] = vl_courseList_o;
            return View();
        }

        public ActionResult Index_Courses_ByLevel(string tab)
        {
            List<CourseModel> vl_courseList_o = new List<CourseModel>();
            Course_BO vl_course_o = new Course_BO();
            vl_courseList_o = vl_course_o.SearchCourse(new CourseModel());
            ViewData["CourseList"] = vl_courseList_o;
            ViewData["Tab"] = tab;
            return View();
        }

        public ActionResult Index_Course(Guid course)
        {
            CourseModel vl_courseModel_o = new CourseModel();
            Course_BO vl_course_o = new Course_BO();
            vl_courseModel_o = vl_course_o.GetCourse(course);
            return View(vl_courseModel_o);
        }

        
        public ActionResult Index_News(Guid news)
        {
            NewsModel vl_newsModel_o = new NewsModel();
            Event_BO vl_event_o = new Event_BO();
            vl_newsModel_o = vl_event_o.GetNews(news);
            return View(vl_newsModel_o);
        }

        public ActionResult Index_Event(Guid eventid)
        {
            EventModel vl_eventModel_o = new EventModel();
            Event_BO vl_event_o = new Event_BO();
            vl_eventModel_o = vl_event_o.GetEvent(eventid);
            return View(vl_eventModel_o);
        }
    }
}