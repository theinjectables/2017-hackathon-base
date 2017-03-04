
using Microsoft.Azure.Management.Fluent;

namespace TheInjectables.Foundation.PaaSPort.Abstractions.Client
{
    public interface IAzureManager
    {
        bool Connected { get; }
        IAzure AzureSerivce { get; }
    }
}
