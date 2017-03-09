using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Sitecore.DataExchange.Plugins;
using TheInjectables.Foundation.PaaSPort.Abstractions.Pipelines;

namespace TheInjectables.Feature.PaaSPort.Azure.Pipelines.GetResourceGroups
{
    public class GetResourceGroupsArgs : AzureServicePipelineArgs<IterableDataSettings>
    {
        public GetResourceGroupsArgs()
        {
        }
    }
}