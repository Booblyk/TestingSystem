using System.Web.Mvc;
using System.Security.Principal;
using TestingSystem.DataBaseConfigurations;
using TestingSystem.Web.Models.Account;
using TestingSystem.Entities;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TestingSystem.Web.Security
{
    public class Account
    {
        [Display(Name = "Username")]

        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
    public static class SessionPersister
    {
        static string usernameSessionvar = "username";

        public static string Username
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[usernameSessionvar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[usernameSessionvar] = value;
            }
        }
    }
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filtercontext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
                filtercontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Index" }));
            else
            {               
                AccountModel am = new AccountModel();
                CustomPrincipal mp = new CustomPrincipal(am.Find(SessionPersister.Username));
                if (!mp.IsInRole(Roles))
                    filtercontext.Result = new RedirectToRouteResult((new RouteValueDictionary(new { controller = "Account", action = "AccessDenied" })));
            }
        }
    }
    public class CustomPrincipal : IPrincipal
    {
        private User account;
        //private AccountModel am = new AccountModel();
        public CustomPrincipal(User account)
        {
            this.account = account;
            this.Identity = new GenericIdentity(account.Email);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            if (role == account.Role)
                return true;
            else
                return false;

        }
    }
}
