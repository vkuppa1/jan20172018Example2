
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity.EntityFramework;
#endregion

//You can add User data for the user by adding more properties to your User class, 
//please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
namespace Chinook.Data.Entities.Security
{
    public class ApplicationUser : IdentityUser
    {
        //We can add the additional attributes that we will be physically included in to 
        //the ASP.NET users table.Security Table.
        public int? EmployeeID { get; set; }
        public int? CustomerID { get; set; }
    }
}
