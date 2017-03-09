using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using TheInjectables.Foundation.PaaSPort.Abstractions.Client.Authentication;

namespace TheInjectables.Foundation.PaaSPort.Abstractions.Client
{
    public interface IAzureServiceManager
    {
        IAzure GetAzureService(IAzureCredential credentials);
    }
}
