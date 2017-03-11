using System;
using Sitecore.sitecore.admin;
using TheInjectables.Feature.PaaSPort.Azure.Client;
using TheInjectables.Feature.PaaSPort.Azure.Client.Authentication;

namespace TheInjectables.Project.PaaSPort.Website.util
{
    public partial class TestAzure : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSecurity();

            var tenantid = "4346f2c6-6ec4-491d-9a3d-c4b3877e616b";
            var key = "UPMUIU+kEA7Sc4UwuwcgrEM0iu1bISjRrlsdLvgCSM4=";
            var client = "b8060a58-e98b-4e58-ba11-22269a084e2c";
            var subscription = "ffecf118-fbde-455a-ad01-8ad9541a9827";

            var credential = new AzureCredentials
            {
                ClientId = client,
                TenantId = tenantid,
                Key = key,
                SubscriptionId = subscription
            };

            var azure = new DefaultAzureManager(credential);

            if (azure.Connected)
                litOutput.Text = string.Format("{0}<br>{1}<hr>", litOutput.Text, "Azure Connected");

            foreach (var resourceGroup in azure.GetResourceGroups())
            {
                litOutput.Text += string.Format("<h2>{0}</h2>", resourceGroup.Name);

                litOutput.Text += "<h3>App Services</h3><ul>";
                foreach (var webApp in azure.GetAppServicePlans(resourceGroup.Name))
                    litOutput.Text += string.Format("<li>{0}: {1}</li>", webApp.Name, webApp.PricingTier);
                litOutput.Text += "</ul>";

                //litOutput.Text += "<h3>Web Apps</h3><ul>";
                //foreach (var webApp in azure.GetWebApps(resourceGroup.Name))
                //{
                //    litOutput.Text += string.Format("<li>{0}: {1}</li>", webApp.Name, webApp.State);

                //}
                //litOutput.Text += string.Format("</ul>");
            }
        }
    }
}