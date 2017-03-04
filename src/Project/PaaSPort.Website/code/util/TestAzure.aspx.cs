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

            string tenantid = "7b4c6035-b43b-4dc4-b847-b01a13ad108d";
            string key = "PaaSPort12345 ";
            string client = "881b3fc5-2ad4-4fdf-8f14-ebf82195e28c";
            string subscription = "3f5e6482-7c15-40fb-a7e0-4849a9bbdd3b";

            var credential = new AzureCredential()
            {
                ClientId = client,
                TenantId = tenantid,
                PassPhrase = key,
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
                {
                    litOutput.Text += string.Format("<li>{0}: {1}</li>", webApp.Name, webApp.PricingTier);

                }
                litOutput.Text += string.Format("</ul>");

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