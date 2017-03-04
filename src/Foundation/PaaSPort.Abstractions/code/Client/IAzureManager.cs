
using System.Collections.Generic;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;

namespace TheInjectables.Foundation.PaaSPort.Abstractions.Client
{
    public interface IAzureManager
    {
        bool Connected { get; }
        IAzure AzureSerivce { get; }

        IEnumerable<IResourceGroup> GetResourceGroups();
    }
}
