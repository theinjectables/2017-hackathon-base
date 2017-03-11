using System.Collections.Generic;
using Microsoft.Azure.Management.AppService.Fluent;
using Sitecore.DataExchange.Plugins;

namespace TheInjectables.Feature.PaaSPort.Azure.Pipelines.GetWebApps
{
    public class GetWebAppsProcessor : BaseGetWebAppsProcessor
    {
        public override void Process(GetWebAppsArgs args)
        {
            var groups = AzureService.ResourceGroups.List();
            var resultList = new List<IWebApp>();

            foreach (var group in groups)
            {
                var webApps = AzureService.AppServices.WebApps.ListByGroup(group.Name);
                if (webApps != null)
                    resultList.AddRange(webApps);
            }

            var result = new IterableDataSettings(resultList);

            args.Result = result;
        }
    }
}