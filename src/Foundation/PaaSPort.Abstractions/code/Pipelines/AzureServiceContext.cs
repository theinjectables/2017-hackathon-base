using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Management.Fluent;
using Sitecore.Common;

namespace TheInjectables.Foundation.PaaSPort.Abstractions.Pipelines
{
    public class AzureServiceContext : Switcher<IAzure, AzureServiceContext>
    {
        public static bool IsConnected => !string.IsNullOrEmpty(CurrentValue?.GetCurrentSubscription().SubscriptionId);

        public AzureServiceContext(IAzure azureService) : base(azureService)
        {
        }
    }
}