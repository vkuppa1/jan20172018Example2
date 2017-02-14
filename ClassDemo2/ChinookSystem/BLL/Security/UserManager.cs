using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using ChinookSystem.DAL.Security;
#endregion

namespace ChinookSystem.BLL.Security
{
    public class UserManager : UserManager<ApplicationUser>
    {


        private const string STR_DEFAULT_PASSWORD = "Pa$$word1";
        /// <summary>Requires FirstName and LastName</summary>
        private const string STR_USERNAME_FORMAT = "{0}.{1}";
        /// <summary>Requires UserName</summary>
        private const string STR_EMAIL_FORMAT = "{0}@Chinook.ca";
        private const string STR_WEBMASTER_USERNAME = "Webmaster";

        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {




        }

        public void AddWebMaster()
        {
            //Users accrss all the records on the AspNetUsers table 
            //UserName is the user logon userid (dwelch)
            if (!Users.Any(u => u.UserName.Equals(STR_WEBMASTER_USERNAME)))
            {
                var webmasterAccount = new ApplicationUser()
                {
                    UserName = STR_WEBMASTER_USERNAME,
                    Email = string.Format(STR_EMAIL_FORMAT, STR_WEBMASTER_USERNAME)
                };
                //Place the webmaster account on the ASPNEtUSers table
                this.Create(webmasterAccount, STR_DEFAULT_PASSWORD);
                //Place an account role the record on the ASPNetUserRoles table
                //.Id comes from the webmasterAccount and is the pkey is from the User Table
                //Rolwe will come from the Entities.Security.SecuritysRoles
                this.AddToRole(webmasterAccount.Id, SecurityRoles.WebsiteAdmins);
            }
        }
    }
}
