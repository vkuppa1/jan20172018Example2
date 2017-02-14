﻿<%@ Application Language="C#" %>
<%@ Import Namespace="Website2" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@Import Namespace="ChinookSystem.BLL.Security"%>


<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        //Create the startup default roles
        //Create the webnmaster User
        //Create the employee user accounts
        //When the application starts up.

        var rolemgr = new RoleManager();
        rolemgr.AddDefaultRoles();
        var usermgr = new UserManager();
        usermgr.AddWebMaster();

    }

</script>
