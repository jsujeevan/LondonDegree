using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LondonDegree_Web.Helpers;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class Support_BO
    {

        public void setUserSession(Guid in_person_gu, Guid in_session_gu)
        {
            try
            {
                HttpContext.Current.Session["ss_UserId_gu"] = in_person_gu;
                HttpContext.Current.Session["ss_SessionId_gu"] = in_session_gu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Guid getCurrentUser()
        {
            try
            {
                return Guid.Parse(HttpContext.Current.Session["ss_UserId_gu"].ToString());
            }
            catch (Exception ex)
            {
                throw new SessionNotFoundException("Session user not found");
            }
        }

        public PersonModel getCurrentUserObject()
        {
            PersonModel vl_personModel_o = null;
            Person_BO vl_person_o = new Person_BO();
            try
            {
                Guid vl_person_gu =  Guid.Parse(HttpContext.Current.Session["ss_UserId_gu"].ToString());
                vl_personModel_o = vl_person_o.GetPerson(vl_person_gu);

            }
            catch (Exception ex)
            {
                throw new SessionNotFoundException("Session user object not found");
            }
            return vl_personModel_o;
        }

        public Guid getSystemUser()
        {
            String vl_systemuser_s = "";
            try
            {
                vl_systemuser_s = System.Configuration.ConfigurationManager.AppSettings["SystemUser"];
                return new Guid(vl_systemuser_s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Guid getCurrentSession()
        {
            try
            {
                return Guid.Parse(HttpContext.Current.Session["ss_SessionId_gu"].ToString());
            }
            catch (Exception ex)
            {
                throw new SessionNotFoundException("Session not found");
            }
        }
    }
}