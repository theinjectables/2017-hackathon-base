using System.Collections.Generic;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;

namespace TheInjectables.Feature.PaaSPort.Azure.Client
{
    // TODO: delete me
    public interface IAzureManager
    {
        bool Connected { get; }
        IAzure AzureSerivce { get; }

        IEnumerable<IResourceGroup> GetResourceGroups();
    }
}