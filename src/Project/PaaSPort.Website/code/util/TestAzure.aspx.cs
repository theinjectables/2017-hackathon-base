using System;
using Sitecore.sitecore.admin;

namespace TheInjectables.Project.PaaSPort.Website.util
{
    public partial class TestAzure : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSecurity();

            

        }
    }
}