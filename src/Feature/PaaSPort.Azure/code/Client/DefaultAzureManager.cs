using System.Collections.Generic;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using TheInjectables.Foundation.PaaSPort.Azure.Service.Authentication;

namespace TheInjectables.Feature.PaaSPort.Azure.Client
{
    // TODO: delete me
    public class DefaultAzureManager : BaseAzureManager
    {
        public DefaultAzureManager(IAzureCredentials credentials) : base(credentials)
        {
        }

        public override IEnumerable<IResourceGroup> GetResourceGroups()
        {
            var groups = AzureSerivce.ResourceGroups.List();

            if (groups.Count > 0)
                return groups;

            return new List<IResourceGroup>();
        }

        public IEnumerable<IAppServicePlan> GetAppServicePlans(string resourceGroupName)
        {
            var webApps = AzureSerivce.AppServices.AppServicePlans.ListByGroup(resourceGroupName);
            if (webApps.Count > 0)
                return webApps;

            return new List<IAppServicePlan>();
        }

        public IEnumerable<IWebApp> GetWebApps(string resourceGroupName)
        {
            var webApps = AzureSerivce.AppServices.WebApps.ListByGroup(resourceGroupName);
            if (webApps.Count > 0)
                return webApps;

            return new List<IWebApp>();
        }
    }
}