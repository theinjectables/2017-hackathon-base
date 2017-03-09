using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Sitecore.DataExchange.Plugins;

namespace TheInjectables.Feature.PaaSPort.Azure.Pipelines.GetResourceGroups
{
    public class GetResourceGroupsProcessor : BaseGetResourceGroupsProcessor
    {
        public override void Process(GetResourceGroupsArgs args)
        {
            var groups = AzureService.ResourceGroups.List();

            var result = groups.Count > 0
                ? new IterableDataSettings(groups)
                : new IterableDataSettings(new List<IResourceGroup>());

            args.Result = result;
        }
    }
}