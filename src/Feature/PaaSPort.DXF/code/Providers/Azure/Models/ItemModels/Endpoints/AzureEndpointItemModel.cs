using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Services.Core.Model;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Models.ItemModels.Endpoints
{
    public class AzureEndpointItemModel : ItemModel
    {
        public const string TenantId = "TenantId";
        public const string Key = "Key";
        public const string Client = "Client";
        public const string Subscription = "Subscription";

        public const string ServiceManagerConfigurationPath = "ServiceManagerConfigurationPath";
    }
}