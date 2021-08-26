using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LondonDegree_Web.Models;
using LondonDegree_Web.BO;
using System.Collections.Generic;
using LondonDegree_Web.Helpers;
using System.Net;

namespace LondonDegree_Web.Controllers
{
    [Authorize]
    [MonitorError]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        /*
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        */

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            bool vl_validAccount_z = false;
            Guid vl_loginIdentity_gu = Guid.Empty;
            PersonModel vl_personModel_o = new PersonModel();
            PersonLoginModel vl_personLoginModel_o = new PersonLoginModel();

            Account_BO vl_account_o = new Account_BO();
            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();
            Object_BO vl_object_o = new Object_BO();

            vl_loginIdentity_gu = Guid.NewGuid();

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    PersonModel vl_personSearchModel_o = new PersonModel();
                    List<PersonModel> vl_personList_o = new List<PersonModel>();
                    vl_personSearchModel_o.Person_Email_s = model.Email;

                    vl_personList_o = vl_person_o.FindPerson(vl_personSearchModel_o);
                    if (vl_personList_o.Count > 0)
                    {
                        vl_personModel_o = vl_personList_o.First();
                    }

                    AspNetUsersModel vl_aspUser_o = new AspNetUsersModel();
                    AspNetUsersModel vl_aspUserSearch_o = new AspNetUsersModel();
                    List<AspNetUsersModel> vl_aspUserList_o = new List<AspNetUsersModel>();
                    vl_aspUserSearch_o.Email = model.Email;
                    vl_aspUserSearch_o.UserName = model.Email;

                    vl_aspUserList_o = vl_account_o.SearchAspNetUsers(vl_aspUserSearch_o);
                    if (vl_aspUserList_o.Count > 0)
                    {
                        vl_aspUser_o = vl_aspUserList_o.First();
                    }

                    if (!string.IsNullOrEmpty(vl_personModel_o.Person_Email_s)) {
                        if (vl_personModel_o.Person_Email_s.Equals(vl_aspUser_o.Email, StringComparison.InvariantCultureIgnoreCase))
                        {
                            vl_validAccount_z = true;
                        }
                    }

                    if (vl_validAccount_z)
                    {
                        //Set session and set login log
                        vl_support_o.setUserSession(vl_personModel_o.PK_Person_ID_gu, vl_loginIdentity_gu);
                        vl_personLoginModel_o.FK_Person_ID_gu = vl_personModel_o.PK_Person_ID_gu;
                        vl_personLoginModel_o.PersonLogin_Attempt_i = 0;
                        vl_personLoginModel_o.PersonLogin_Success_z = true;
                    }
                    else
                    {
                        //Set login log
                        var vl_membershipUser_o = await UserManager.FindByNameAsync(model.Email);
                        UserManager.AccessFailed(vl_membershipUser_o.Id);
                        int vl_FailedAttemptCount_i = vl_membershipUser_o.AccessFailedCount;
                        vl_personLoginModel_o.PersonLogin_Attempt_i = vl_FailedAttemptCount_i;
                        vl_personLoginModel_o.FK_Person_ID_gu = vl_personModel_o.PK_Person_ID_gu;
                        vl_personLoginModel_o.PersonLogin_Success_z = false;

                    }

                    vl_personLoginModel_o.PK_PersonLogin_ID_gu = vl_loginIdentity_gu;
                    vl_personLoginModel_o.PersonLogin_Username_s = model.Email;
                    vl_personLoginModel_o.PersonLogin_Browser_s = vl_account_o.GetClientBrowser(Request);
                    vl_personLoginModel_o.PersonLogin_BrowserDetails_s = vl_account_o.GetClientBrowserInfo(Request);
                    vl_personLoginModel_o.PersonLogin_IP_s = vl_account_o.GetClientIP(Request);
                    vl_personLoginModel_o.PersonLogin_Login_d = DateTime.Now;
                    vl_personLoginModel_o.PersonLogin_Impersonate_z = false;
                    vl_person_o.InsertPersonLogin(vl_personLoginModel_o);

                    //Dispatch response
                    if (vl_validAccount_z)
                    {
                        //Get user menu items
                        List<ObjectModel> vl_userObjectList_o = null;
                        LinkedList<ObjectModel> vl_navigationMenu_o = null;
                        vl_userObjectList_o = vl_object_o.SearchObjectMenuItemsByRole(vl_personModel_o.FK_PersonRole_ID_i);
                        vl_navigationMenu_o = vl_object_o.GetNavigationMenu(vl_userObjectList_o);
                        if (vl_navigationMenu_o.Count > 0)
                        {
                            ObjectModel vl_menuObject_o = vl_navigationMenu_o.OrderBy(m => m.Object_Order_i).First();
                            return RedirectToAction(vl_menuObject_o.Object_Action_s, vl_menuObject_o.Object_Controller_s);
                        }
                        else
                        {
                            return RedirectToAction("MyProfileIndex", "Dashboard");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                    await UpdateLoginLog(vl_loginIdentity_gu, model.Email);
                    return RedirectToAction("Index", "Home");
                default:
                    await UpdateLoginLog(vl_loginIdentity_gu, model.Email);
                    return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }
        /*
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        */
        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }


                string vl_template_s = "";
                string vl_message_s = "";
                string vl_subject_s = "";
                Guid vl_systemUser_gu = Guid.Empty;
                EmailTemplateModel vl_emailTemplateModel_o = null;
                PersonModel vl_personModel_o = new PersonModel();

                Email_BO vl_email_o = new Email_BO();
                Account_BO vl_Account_o = new Account_BO();
                Person_BO vl_person_o = new Person_BO();
                Support_BO vl_support_o = new Support_BO();

                PersonModel vl_personSearchModel_o = new PersonModel();
                List<PersonModel> vl_personList_o = new List<PersonModel>();
                vl_personSearchModel_o.Person_Email_s = model.Email;

                vl_personList_o = vl_person_o.FindPerson(vl_personSearchModel_o);
                if (vl_personList_o.Count > 0)
                {
                    vl_personModel_o = vl_personList_o.First();
                }


                if (vl_personModel_o.PK_Person_ID_gu == Guid.Empty)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                string passwordresetcode = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var vl_callbackUrl_s = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = passwordresetcode }, protocol: Request.Url.Scheme);

                vl_template_s = System.Configuration.ConfigurationManager.AppSettings["PasswordReset"];
                vl_systemUser_gu = vl_support_o.getSystemUser();

                //Get email template
                vl_emailTemplateModel_o = vl_email_o.GetEmailTemplate(new Guid(vl_template_s));

                vl_subject_s = vl_emailTemplateModel_o.EmailTemplate_Name_s;
                vl_message_s = vl_emailTemplateModel_o.EmailTemplate_Message_s;
                vl_message_s = vl_message_s.Replace("[@FirstnameLabel]", vl_personModel_o.Person_FirstName_s);
                vl_message_s = vl_message_s.Replace("[@PasswordResetUrl]", vl_callbackUrl_s);

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

                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string userId, string code)
        {
            //var user = UserManager.FindByNameAsync(userId);
            var user = UserManager.FindById(userId);
            ResetPasswordViewModel vl_resetPasswordModel_o = new ResetPasswordViewModel();
            vl_resetPasswordModel_o.Email = user.Email;
            vl_resetPasswordModel_o.Code = code;
            return code == null ? View("Error") : View(vl_resetPasswordModel_o);
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [Authorize]
        [MonitorSession]
        [MonitorError]
        public async Task<ActionResult> InternalAccountReset(Guid person)
        {
            string vl_template_s = "";
            string vl_message_s = "";
            string vl_subject_s = "";
            Guid vl_systemUser_gu = Guid.Empty;
            Guid vl_currentUser_gu = Guid.Empty;
            PersonModel vl_personModel_o = new PersonModel();
            EmailTemplateModel vl_emailTemplateModel_o = new EmailTemplateModel();

            Person_BO vl_person_o = new Person_BO();
            Support_BO vl_support_o = new Support_BO();
            Email_BO vl_email_o = new Email_BO();

            vl_personModel_o = vl_person_o.GetPerson(person);

            var user = await UserManager.FindByNameAsync(vl_personModel_o.Person_Email_s);
            string passwordresetcode = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            var vl_callbackUrl_s = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = passwordresetcode }, protocol: Request.Url.Scheme);

            vl_template_s = System.Configuration.ConfigurationManager.AppSettings["PasswordReset"];
            vl_currentUser_gu = vl_support_o.getCurrentUser();
            vl_systemUser_gu = vl_support_o.getSystemUser();

            vl_emailTemplateModel_o = vl_email_o.GetEmailTemplate(new Guid(vl_template_s));

            vl_subject_s = vl_emailTemplateModel_o.EmailTemplate_Name_s;
            vl_message_s = vl_emailTemplateModel_o.EmailTemplate_Message_s;
            vl_message_s = vl_message_s.Replace("[@FirstnameLabel]", vl_personModel_o.Person_FirstName_s);
            vl_message_s = vl_message_s.Replace("[@PasswordResetUrl]", vl_callbackUrl_s);

            //Send email
            EmailModel vl_emailModel_o = new EmailModel();
            vl_emailModel_o.PK_Email_ID_gu = Guid.NewGuid();
            vl_emailModel_o.Email_Subject_s = vl_subject_s;
            vl_emailModel_o.Email_Message_s = vl_message_s;
            vl_emailModel_o.FK_Person_From_ID_gu = vl_currentUser_gu;
            vl_emailModel_o.FK_Person_To_ID_gu = vl_personModel_o.PK_Person_ID_gu;
            vl_emailModel_o.Person_To_Email_s = vl_personModel_o.Person_Email_s;
            vl_emailModel_o.Email_Sent_d = DateTime.Now;

            SendGrid_API vl_sendGrid_o = new SendGrid_API();
            string vl_status_s = vl_sendGrid_o.SendEmail(vl_emailModel_o);
            vl_emailModel_o.Email_Success_z = true;

            vl_email_o.InsertEmail(vl_emailModel_o);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ContentResult vl_Return_o = new ContentResult();
            vl_Return_o.Content = person.ToString();
            return vl_Return_o;
        }

        [Authorize]
        [MonitorSession]
        [MonitorError]
        public async Task<ActionResult> CreateAccount(Guid person)
        {
            bool vl_hasError_z = false;
            string vl_password_s = "";
            string vl_template_s = "";
            string vl_message_s = "";
            string vl_subject_s = "";
            Guid vl_currentUser_gu = Guid.Empty;

            PersonModel vl_personModel_o = null;
            EmailTemplateModel vl_emailTemplateModel_o = null;
            Person_BO vl_PersonBO_o = new Person_BO();
            Email_BO vl_emailBO_o = new Email_BO();
            Support_BO vl_support_o = new Support_BO();

            vl_personModel_o = vl_PersonBO_o.GetPerson(person);
            vl_template_s = System.Configuration.ConfigurationManager.AppSettings["NewAccount"];
            vl_currentUser_gu = vl_support_o.getCurrentUser();

            vl_password_s = vl_personModel_o.Person_FirstName_s + "LD100%";
            var user = new ApplicationUser { UserName = vl_personModel_o.Person_Email_s, Email = vl_personModel_o.Person_Email_s };
            var result = await UserManager.CreateAsync(user, vl_password_s);
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                var confirmedresult = await UserManager.ConfirmEmailAsync(user.Id, code);
                string passwordresetcode = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var vl_callbackUrl_s = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = passwordresetcode }, protocol: Request.Url.Scheme);
                //Get communication template
                vl_emailTemplateModel_o = vl_emailBO_o.GetEmailTemplate(new Guid(vl_template_s));

                vl_subject_s = vl_emailTemplateModel_o.EmailTemplate_Name_s;
                vl_message_s = vl_emailTemplateModel_o.EmailTemplate_Message_s;
                vl_message_s = vl_message_s.Replace("[@FirstnameLabel]", vl_personModel_o.Person_FirstName_s);
                vl_message_s = vl_message_s.Replace("[@PasswordResetUrl]", vl_callbackUrl_s);

                //Send email with the url
                EmailModel vl_emailModel_o = new EmailModel();
                vl_emailModel_o.PK_Email_ID_gu = Guid.NewGuid();
                vl_emailModel_o.Email_Subject_s = vl_subject_s;
                vl_emailModel_o.Email_Message_s = vl_message_s;
                vl_emailModel_o.FK_Person_From_ID_gu = vl_currentUser_gu;
                vl_emailModel_o.FK_Person_To_ID_gu = person;
                vl_emailModel_o.Person_To_Email_s = vl_personModel_o.Person_Email_s;
                vl_emailModel_o.Email_Sent_d = DateTime.Now;

                SendGrid_API vl_sendGrid_o = new SendGrid_API();
                string vl_status_s = vl_sendGrid_o.SendEmail(vl_emailModel_o);
                vl_emailModel_o.Email_Success_z = true;

                vl_emailBO_o.InsertEmail(vl_emailModel_o);

            }
            //AddErrors(result);

            if (result.Errors.Count() > 0)
            {
                vl_hasError_z = true;
            }

            if (vl_hasError_z)
            {
                string vl_ErrorText_s = "";
                foreach (var error in result.Errors)
                {
                    vl_ErrorText_s += error + "; ";
                }
                throw new MembershipException(vl_ErrorText_s);
            }
            else
            {

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ContentResult vl_Return_o = new ContentResult();
                vl_Return_o.Content = person.ToString();
                return vl_Return_o;
            }

        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LogOff(Guid person, Guid session)
        {
            Session.Remove("ss_SessionId_gu");
            Session.Remove("ss_UserId_gu");
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        private async Task UpdateLoginLog(Guid vl_loginIdentity_gu, string vl_email_s)
        {
            Person_BO vl_person_o = new Person_BO();
            Account_BO vl_account_o = new Account_BO();
            PersonModel vl_systemUser_o = new PersonModel();

            PersonLoginModel vl_personLoginModel_o = new PersonLoginModel();
            List<PersonModel> vl_personList_o = new List<PersonModel>();
            PersonModel vl_personSearchModel_o = new PersonModel();
            vl_personSearchModel_o.Person_Email_s = vl_email_s;
            vl_personList_o = vl_person_o.SearchPerson(vl_personSearchModel_o);

            if (vl_personList_o.Count > 0)
            {
                vl_systemUser_o = vl_personList_o.First();
            }

            if (vl_systemUser_o.PK_Person_ID_gu != Guid.Empty)
            {
                AspNetUsersModel vl_aspUser_o = new AspNetUsersModel();
                AspNetUsersModel vl_aspUserSearch_o = new AspNetUsersModel();
                List<AspNetUsersModel> vl_aspUserList_o = new List<AspNetUsersModel>();
                vl_aspUserSearch_o.Email = vl_email_s;
                vl_aspUserSearch_o.UserName = vl_email_s;

                vl_aspUserList_o = vl_account_o.SearchAspNetUsers(vl_aspUserSearch_o);
                if (vl_aspUserList_o.Count > 0)
                {
                    vl_aspUser_o = vl_aspUserList_o.First();
                }
                if (!string.IsNullOrEmpty(vl_aspUser_o.Email))
                {
                    if (vl_systemUser_o.Person_Email_s.Equals(vl_aspUser_o.Email, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var vl_membershipUser_o = await UserManager.FindByNameAsync(vl_email_s);
                        UserManager.AccessFailed(vl_membershipUser_o.Id);
                        int vl_FailedAttemptCount_i = vl_membershipUser_o.AccessFailedCount;
                        vl_personLoginModel_o.PersonLogin_Attempt_i = vl_FailedAttemptCount_i;
                    }
                }
                vl_personLoginModel_o.FK_Person_ID_gu = vl_systemUser_o.PK_Person_ID_gu;

            }
            else
            {
                vl_personLoginModel_o.FK_Person_ID_gu = Guid.Empty;
                vl_personLoginModel_o.PersonLogin_Attempt_i = 0;
            }


            vl_personLoginModel_o.PersonLogin_Success_z = false;
            vl_personLoginModel_o.PersonLogin_Username_s = vl_email_s;
            vl_personLoginModel_o.PersonLogin_Browser_s = vl_account_o.GetClientBrowser(Request);
            vl_personLoginModel_o.PersonLogin_BrowserDetails_s = vl_account_o.GetClientBrowserInfo(Request);
            vl_personLoginModel_o.PersonLogin_IP_s = vl_account_o.GetClientIP(Request);
            vl_personLoginModel_o.PersonLogin_Login_d = DateTime.Now;
            vl_personLoginModel_o.PK_PersonLogin_ID_gu = vl_loginIdentity_gu;
            vl_person_o.InsertPersonLogin(vl_personLoginModel_o);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}