using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LondonDegree_Web.Models;
using LondonDegree_Web.BO;
using LondonDegree_Web.Helpers;
using System.Net;

namespace LondonDegree_Web.Controllers
{
    [Authorize]
    [MonitorSession]
    [MonitorError]
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult SearchEnquiries()
        {
            List<PersonModel> vl_peopleList_o = new List<PersonModel>();
            List<PersonEnquiryStatusModel> vl_enquiryStatusList_o = new List<PersonEnquiryStatusModel>();
            PersonEnquiryModel vl_enquiryModel_o = new PersonEnquiryModel();
            PersonModel vl_personModel_o = new PersonModel();
            Person_BO vl_person_o = new Person_BO();
            vl_personModel_o.Person_Archive_z = false;
            vl_peopleList_o = vl_person_o.SearchPerson(vl_personModel_o);
            vl_enquiryStatusList_o = vl_person_o.SearchPersonEnquiryStatus(new PersonEnquiryStatusModel());
            ViewData["PeopleList"] = vl_peopleList_o;
            ViewData["StatusList"] = vl_enquiryStatusList_o;
            return View(vl_enquiryModel_o);
        }

        [HttpPost]
        public JsonResult SearchEnquiries(PersonEnquiryModel in_personEnquiryModel_o)
        {
            List<PersonEnquiryModel> vl_personEnquiryList_o = null;
            Person_BO vl_person_o = new Person_BO();
            vl_personEnquiryList_o = vl_person_o.SearchPersonEnquiry(in_personEnquiryModel_o);
            return Json(vl_personEnquiryList_o);
        }

        
        public ActionResult Index_Enquiry(Guid enquiry)
        {
            List<PersonEnquiryCommunicationModel> vl_enquiryCommList_o = new List<PersonEnquiryCommunicationModel>();
            PersonEnquiryModel vl_peopleEnquiry_o = new PersonEnquiryModel();
            Person_BO vl_person_o = new Person_BO();
            vl_peopleEnquiry_o = vl_person_o.GetPersonEnquiry(enquiry);
            PersonEnquiryCommunicationModel vl_commSearchModel_o = new PersonEnquiryCommunicationModel();
            vl_commSearchModel_o.FK_PersonEnquiry_ID_gu = enquiry;
            vl_enquiryCommList_o = vl_person_o.SearchPersonEnquiryCommunication(vl_commSearchModel_o);
            ViewData["EnquiryList"] = vl_enquiryCommList_o;
            return View(vl_peopleEnquiry_o);
        }

        

        public ActionResult EditEnquiryDetails(String modal, Guid id)
        {
            PersonEnquiryModel vl_peopleEnquiry_o = new PersonEnquiryModel();
            List<PersonEnquiryStatusModel> vl_enquiryStatusList_o = new List<PersonEnquiryStatusModel>();
            Person_BO vl_person_o = new Person_BO();
            vl_peopleEnquiry_o = vl_person_o.GetPersonEnquiry(id);
            vl_enquiryStatusList_o = vl_person_o.SearchPersonEnquiryStatus(new PersonEnquiryStatusModel());
            ViewData["StatusList"] = vl_enquiryStatusList_o;
            ViewData["mainHeading"] = "Edit Enquiry";
            ViewData["modalDialog"] = modal;
            return View(vl_peopleEnquiry_o);
        }

        [HttpPost]
        public ActionResult EditEnquiryDetails(PersonEnquiryModel in_personEnquiryModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_courseUpdated_z = false;
            string vl_ErrorText_s = "";
            Person_BO vl_person_o = new Person_BO();
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

                in_personEnquiryModel_o.FK_Person_Modified_ID_gu = vl_support_o.getCurrentUser();
                in_personEnquiryModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_courseUpdated_z = vl_person_o.UpdatePersonEnquiry(in_personEnquiryModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_personEnquiryModel_o.PK_PersonEnquiry_ID_gu.ToString();
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

        [HttpPost]
        public ActionResult AddNewEnquiryCommunication(PersonEnquiryCommunicationModel in_personEnquiryCommModel_o)
        {
            Guid vl_personCommID_gu = Guid.NewGuid();
            bool vl_validModel_z = false;
            bool vl_Inserted_z = false;
            string vl_emailRequired_s = "";
            string vl_ErrorText_s = "";

            string vl_template_s = "";
            string vl_message_s = "";
            string vl_subject_s = "";
            Guid vl_systemUser_gu = Guid.Empty;
            EmailTemplateModel vl_emailTemplateModel_o = null;
            PersonModel vl_personModel_o = new PersonModel();

            Email_BO vl_email_o = new Email_BO();

            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();
            //Validate model
            vl_validModel_z = ModelState.IsValid ? true : false;


            if (vl_validModel_z)
            {
                vl_emailRequired_s = Request["Email_Notification_z"];
                in_personEnquiryCommModel_o.EmailRequired_z = string.IsNullOrEmpty(vl_emailRequired_s) ? false : true;

                in_personEnquiryCommModel_o.PK_PersonEnquiryCommunication_ID_gu = vl_personCommID_gu;
                in_personEnquiryCommModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_personEnquiryCommModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();

                //Sent email
                if (in_personEnquiryCommModel_o.EmailRequired_z)
                {
                    PersonEnquiryModel vl_peopleEnquiry_o = new PersonEnquiryModel();
                    vl_peopleEnquiry_o = vl_person_o.GetPersonEnquiry(in_personEnquiryCommModel_o.FK_PersonEnquiry_ID_gu);
                    vl_personModel_o = vl_person_o.GetPerson(vl_peopleEnquiry_o.FK_Person_ID_gu);

                    vl_template_s = System.Configuration.ConfigurationManager.AppSettings["Enquiry"];
                    vl_systemUser_gu = vl_support_o.getSystemUser();

                    //Get email template
                    vl_emailTemplateModel_o = vl_email_o.GetEmailTemplate(new Guid(vl_template_s));

                    vl_subject_s = vl_emailTemplateModel_o.EmailTemplate_Name_s+" "+ vl_peopleEnquiry_o.PersonEnquiry_Ref_s;
                    vl_message_s = vl_emailTemplateModel_o.EmailTemplate_Message_s;
                    vl_message_s = vl_message_s.Replace("[@FirstnameLabel]", vl_personModel_o.Person_FirstName_s);
                    vl_message_s = vl_message_s.Replace("[@Message]", in_personEnquiryCommModel_o.PersonEnquiryCommunication_s.Replace(System.Environment.NewLine, "<br>"));

                    EmailModel vl_emailModel_o = new EmailModel();
                    vl_emailModel_o.PK_Email_ID_gu = Guid.NewGuid();
                    vl_emailModel_o.Email_Subject_s = vl_subject_s;
                    vl_emailModel_o.Email_Message_s = vl_message_s;
                    vl_emailModel_o.FK_Person_From_ID_gu = vl_systemUser_gu;
                    vl_emailModel_o.FK_Person_To_ID_gu = vl_personModel_o.PK_Person_ID_gu;
                    vl_emailModel_o.Person_To_Email_s = vl_personModel_o.Person_Email_s;
                    vl_emailModel_o.Email_Sent_d = DateTime.Now;

                    SendGrid_API vl_sendGrid_o = new SendGrid_API();
                    string vl_status_s = vl_sendGrid_o.SendEmail(vl_emailModel_o);
                    vl_emailModel_o.Email_Success_z = true;

                    vl_email_o.InsertEmail(vl_emailModel_o);
                    in_personEnquiryCommModel_o.EmailSent_z = true;
                }

                vl_Inserted_z = vl_person_o.InsertPersonEnquiryCommunication(in_personEnquiryCommModel_o);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_personEnquiryCommModel_o.FK_PersonEnquiry_ID_gu.ToString();
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


        public ActionResult SearchEvents()
        {
            EventModel vl_eventModel_o = new EventModel();
            return View(vl_eventModel_o);
        }

        [HttpPost]
        public JsonResult SearchEvents(EventSearchModel in_eventSearchModel_o)
        {
            List<EventModel> vl_eventList_o = null;
            Event_BO vl_event_o = new Event_BO();
            vl_eventList_o = vl_event_o.SearchEvent(in_eventSearchModel_o);
            return Json(vl_eventList_o);
        }

        public ActionResult Index_Event(Guid eventid)
        {
            EventModel vl_eventModel_o = new EventModel();
            Event_BO vl_event_o = new Event_BO();
            vl_eventModel_o = vl_event_o.GetEvent(eventid);
            return View(vl_eventModel_o);
        }


        public ActionResult EditEventDetails(String modal, Guid id)
        {
            EventModel vl_eventModel_o = new EventModel();
            Event_BO vl_event_o = new Event_BO();
            vl_eventModel_o = vl_event_o.GetEvent(id);
            ViewData["mainHeading"] = "Edit Event";
            ViewData["modalDialog"] = modal;
            return View(vl_eventModel_o);
        }

        [HttpPost]
        public ActionResult EditEventDetails(EventModel in_eventModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_courseUpdated_z = false;
            string vl_ErrorText_s = "";
            Event_BO vl_event_o = new Event_BO();
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

                in_eventModel_o.FK_Person_Modified_ID_gu = vl_support_o.getCurrentUser();
                in_eventModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_courseUpdated_z = vl_event_o.UpdateEvent(in_eventModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_eventModel_o.PK_Event_ID_gu.ToString();
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


        public ActionResult SearchNews()
        {
            NewsModel vl_newsModel_o = new NewsModel();
            return View(vl_newsModel_o);
        }

        [HttpPost]
        public JsonResult SearchNews(NewsSearchModel in_SearchModel_o)
        {
            List<NewsModel> vl_newsList_o = null;
            Event_BO vl_event_o = new Event_BO();
            vl_newsList_o = vl_event_o.SearchNews(in_SearchModel_o);
            return Json(vl_newsList_o);
        }

        public ActionResult Index_news(Guid news)
        {
            NewsModel vl_newsModel_o = new NewsModel();
            Event_BO vl_event_o = new Event_BO();
            vl_newsModel_o = vl_event_o.GetNews(news);
            return View(vl_newsModel_o);
        }


        public ActionResult EditNewsDetails(String modal, Guid id)
        {
            List<PersonModel> vl_personList_o = new List<PersonModel>();
            Event_BO vl_event_o = new Event_BO();
            Person_BO vl_person_o = new Person_BO();
            NewsModel vl_newsModel_o = new NewsModel();
            vl_newsModel_o = vl_event_o.GetNews(id);
            vl_personList_o = vl_person_o.SearchPerson(new PersonModel());
            ViewData["PersonList"] = vl_personList_o;
            ViewData["mainHeading"] = "Edit News";
            ViewData["modalDialog"] = modal;
            return View(vl_newsModel_o);
        }

        [HttpPost]
        public ActionResult EditNewsDetails(NewsModel in_newsModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_courseUpdated_z = false;
            string vl_ErrorText_s = "";
            Event_BO vl_event_o = new Event_BO();
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

                in_newsModel_o.FK_Person_Modified_ID_gu = vl_support_o.getCurrentUser();
                in_newsModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_courseUpdated_z = vl_event_o.UpdateNews(in_newsModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_newsModel_o.PK_News_ID_gu.ToString();
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


        public ActionResult AddNewEvents()
        {
            EventModel vl_eventModel_o = new EventModel();
            return View(vl_eventModel_o);
        }

        [HttpPost]
        //[MonitorErrorServer]
        public ActionResult AddNewEvents(EventModel in_eventModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_created_z = false;
            Event_BO vl_event_o = new Event_BO();
            Support_BO vl_support_o = new Support_BO();

            vl_validModel_z = ModelState.IsValid ? true : false;

            if (vl_validModel_z)
            {
                //Create event
                Guid vl_event_gu = Guid.NewGuid();
                in_eventModel_o.PK_Event_ID_gu = vl_event_gu;
                in_eventModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_eventModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_created_z = vl_event_o.InsertEvent(in_eventModel_o);
                //Redirect to person page
                if (vl_created_z)
                {
                    return RedirectToAction("Index_Event", "Administration", new { eventid = vl_event_gu });
                }
                else
                {
                    return View(in_eventModel_o);
                }
            }
            else
            {
                return View(in_eventModel_o);
            }

        }


        public ActionResult AddNewNews()
        {
            List<PersonModel> vl_personList_o = new List<PersonModel>();
            Person_BO vl_person_o = new Person_BO();
            NewsModel vl_newsModel_o = new NewsModel();
            vl_personList_o = vl_person_o.SearchPerson(new PersonModel());
            ViewData["PersonList"] = vl_personList_o;
            return View(vl_newsModel_o);
        }

        [HttpPost]
        //[MonitorErrorServer]
        public ActionResult AddNewNews(NewsModel in_newsModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_created_z = false;
            Event_BO vl_event_o = new Event_BO();
            Support_BO vl_support_o = new Support_BO();

            vl_validModel_z = ModelState.IsValid ? true : false;

            if (vl_validModel_z)
            {
                //Create news
                Guid vl_news_gu = Guid.NewGuid();
                in_newsModel_o.PK_News_ID_gu = vl_news_gu;
                in_newsModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_newsModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_created_z = vl_event_o.InsertNews(in_newsModel_o);
                //Redirect to person page
                if (vl_created_z)
                {
                    return RedirectToAction("Index_News", "Administration", new { news = vl_news_gu });
                }
                else
                {
                    List<PersonModel> vl_personList_o = new List<PersonModel>();
                    Person_BO vl_person_o = new Person_BO();
                    NewsModel vl_newsModel_o = new NewsModel();
                    vl_personList_o = vl_person_o.SearchPerson(new PersonModel());
                    ViewData["PersonList"] = vl_personList_o;
                    return View(vl_newsModel_o);
                }
            }
            else
            {
                List<PersonModel> vl_personList_o = new List<PersonModel>();
                Person_BO vl_person_o = new Person_BO();
                NewsModel vl_newsModel_o = new NewsModel();
                vl_personList_o = vl_person_o.SearchPerson(new PersonModel());
                ViewData["PersonList"] = vl_personList_o;
                return View(vl_newsModel_o);
            }

        }


        public ActionResult AddNewEnquiries()
        {
            List<PersonModel> vl_personList_o = new List<PersonModel>();
            Person_BO vl_person_o = new Person_BO();
            PersonEnquiryModel vl_enquiryModel_o = new PersonEnquiryModel();

            vl_personList_o = vl_person_o.SearchPerson(new PersonModel());
            List<PersonEnquiryStatusModel> vl_enquiryStatusList_o = new List<PersonEnquiryStatusModel>();
            vl_enquiryStatusList_o = vl_person_o.SearchPersonEnquiryStatus(new PersonEnquiryStatusModel());

            ViewData["StatusList"] = vl_enquiryStatusList_o;
            ViewData["PersonList"] = vl_personList_o;
            return View(vl_enquiryModel_o);
        }

        [HttpPost]
        //[MonitorErrorServer]
        public ActionResult AddNewEnquiries(PersonEnquiryModel in_enquiryModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_created_z = false;
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();

            vl_validModel_z = ModelState.IsValid ? true : false;

            if (vl_validModel_z)
            {
                //Create news
                Guid vl_enquiry_gu = Guid.NewGuid();
                string vl_enquiryRef_s = vl_enquiry_gu.ToString().Substring(0,3) + vl_enquiry_gu.ToString().Substring(vl_enquiry_gu.ToString().Length - 2);
                in_enquiryModel_o.PK_PersonEnquiry_ID_gu = vl_enquiry_gu;
                in_enquiryModel_o.PersonEnquiry_Ref_s = vl_enquiryRef_s.ToUpper();
                in_enquiryModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_enquiryModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_created_z = vl_person_o.InsertPersonEnquiry(in_enquiryModel_o);
                //Redirect to person page
                if (vl_created_z)
                {
                    return RedirectToAction("Index_Enquiry", "Administration", new { enquiry = vl_enquiry_gu });
                }
                else
                {
                    List<PersonModel> vl_personList_o = new List<PersonModel>();
                    PersonEnquiryModel vl_enquiryModel_o = new PersonEnquiryModel();

                    vl_personList_o = vl_person_o.SearchPerson(new PersonModel());
                    List<PersonEnquiryStatusModel> vl_enquiryStatusList_o = new List<PersonEnquiryStatusModel>();
                    vl_enquiryStatusList_o = vl_person_o.SearchPersonEnquiryStatus(new PersonEnquiryStatusModel());

                    ViewData["StatusList"] = vl_enquiryStatusList_o;
                    ViewData["PersonList"] = vl_personList_o;
                    return View(vl_enquiryModel_o);
                }
            }
            else
            {
                List<PersonModel> vl_personList_o = new List<PersonModel>();
                PersonEnquiryModel vl_enquiryModel_o = new PersonEnquiryModel();

                vl_personList_o = vl_person_o.SearchPerson(new PersonModel());
                List<PersonEnquiryStatusModel> vl_enquiryStatusList_o = new List<PersonEnquiryStatusModel>();
                vl_enquiryStatusList_o = vl_person_o.SearchPersonEnquiryStatus(new PersonEnquiryStatusModel());

                ViewData["StatusList"] = vl_enquiryStatusList_o;
                ViewData["PersonList"] = vl_personList_o;
                return View(vl_enquiryModel_o);
            }

        }


        
        public ActionResult Index_ContentManagement()
        {
            CMS_BO vl_cms_o = new CMS_BO();
            List<ServiceModel> vl_serviceList_o = new List<ServiceModel>();
            vl_serviceList_o = vl_cms_o.SearchService(new ServiceModel());
            ViewData["ServiceList"] = vl_serviceList_o;
            return View();
        }


        public ActionResult AddNewServices(String modal, Guid id)
        {
            ServiceModel vl_serviceModel_o = new ServiceModel();
            ViewData["mainHeading"] = "Add New Service";
            ViewData["modalDialog"] = modal;

            return View(vl_serviceModel_o);
        }

        [HttpPost]
        public ActionResult AddNewServices(ServiceModel in_serviceModel_o)
        {
            Guid vl_serviceID_gu = Guid.NewGuid();
            bool vl_validModel_z = false;
            bool vl_inserted_z = false;
            string vl_ErrorText_s = "";
            CMS_BO vl_cms_o = new CMS_BO();
            Support_BO vl_support_o = new Support_BO();

            //Validate model
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
                in_serviceModel_o.PK_Service_ID_gu = vl_serviceID_gu;
                in_serviceModel_o.FK_Person_Created_ID_gu = vl_support_o.getCurrentUser();
                in_serviceModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_inserted_z = vl_cms_o.InsertService(in_serviceModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_serviceModel_o.PK_Service_ID_gu.ToString();
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


        public ActionResult EditServices(String modal, Guid id)
        {
            CMS_BO vl_cms_o = new CMS_BO();
            ServiceModel vl_serviceModel_o = new ServiceModel();
            vl_serviceModel_o = vl_cms_o.GetService(id);
            ViewData["mainHeading"] = "Edit Service";
            ViewData["modalDialog"] = modal;

            return View(vl_serviceModel_o);
        }

        

        [HttpPost]
        public ActionResult EditServices(ServiceModel in_serviceModel_o)
        {
            bool vl_validModel_z = false;
            bool vl_updated_z = false;
            string vl_ErrorText_s = "";
            CMS_BO vl_cms_o = new CMS_BO();
            Support_BO vl_support_o = new Support_BO();

            //Validate model
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
                in_serviceModel_o.FK_Person_Modified_ID_gu = vl_support_o.getCurrentUser();
                in_serviceModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
                vl_updated_z = vl_cms_o.UpdateService(in_serviceModel_o);

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = in_serviceModel_o.PK_Service_ID_gu.ToString();
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

        public ActionResult DeleteService(Guid service)
        {
            CMS_BO vl_cms_o = new CMS_BO();
            Support_BO vl_support_o = new Support_BO();
            ServiceModel vl_serviceModel_o = new ServiceModel();
            vl_serviceModel_o.PK_Service_ID_gu = service;
            vl_serviceModel_o.FK_Person_Current_ID_s = vl_support_o.getCurrentUser();
            vl_cms_o.DeleteService(vl_serviceModel_o);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ContentResult vl_Return_o = new ContentResult();
            vl_Return_o.Content = vl_serviceModel_o.PK_Service_ID_gu.ToString();
            return vl_Return_o;
        }

    }
}