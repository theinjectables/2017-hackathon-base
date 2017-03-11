using System.Collections.Generic;
using Microsoft.Azure.Management.AppService.Fluent;
using Sitecore.DataExchange.Plugins;

namespace TheInjectables.Feature.PaaSPort.Azure.Pipelines.GetAppServicePlans
{
    public class GetAppServicePlansProcessor : BaseGetAppServicePlansProcessor
    {
        public override void Process(GetAppServicePlansArgs args)
        {
            var groups = AzureService.ResourceGroups.List();
            var resultList = new List<IAppServicePlan>();

            foreach (var group in groups)
            {
                var webApps = AzureService.AppServices.AppServicePlans.ListByGroup(group.Name);
                if (webApps != null)
                    resultList.AddRange(webApps);
            }

            var result = new IterableDataSettings(resultList);

            args.Result = result;
        }
    }
}