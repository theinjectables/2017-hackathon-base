$ArmTemplatePath = "azuredeploy.json";
$ArmParametersPath = "azuredeploy.parameters.json";

# read the contents of your Sitecore license file
$licenseFileContent = Get-Content -Raw -Encoding UTF8 -Path "license.xml" | Out-String;
$Name = "Injectables2017";
$location = "East US";
$AzureSubscriptionId = "3f5e6482-7c15-40fb-a7e0-4849a9bbdd3b";

#region Create Params Object
# license file needs to be secure string and adding the params as a hashtable is the only way to do it
$additionalParams = New-Object -TypeName Hashtable;

$params = Get-Content $ArmParametersPath -Raw | ConvertFrom-Json;

foreach($p in $params | Get-Member -MemberType *Property)
{
    $additionalParams.Add($p.Name, $params.$($p.Name).value);
}

$additionalParams.Set_Item('licenseXml', $licenseFileContent);
$additionalParams.Set_Item('deploymentId', $Name);

#endregion

#region Service Principle Details

# By default this script will prompt you for your Azure credentials but you can update the script to use an Azure Service Principal instead by following the details at the link below and updating the four variables below once you are done.
# https://azure.microsoft.com/en-us/documen tation/articles/resource-group-authenticate-service-principal/

$UseServicePrinciple = $true;
$TenantId = "7b4c6035-b43b-4dc4-b847-b01a13ad108d";
$ApplicationId = "881b3fc5-2ad4-4fdf-8f14-ebf82195e28c";
$ApplicationPassword = "PaaSPort12345";

#endregion

try {
    Write-Host "Setting Azure RM Context..."

    if($UseServicePrinciple -eq $true)
    {
        #region Use Service Principle
        $secpasswd = ConvertTo-SecureString $ApplicationPassword -AsPlainText -Force
        $mycreds = New-Object System.Management.Automation.PSCredential ($ApplicationId, $secpasswd)
        Login-AzureRmAccount -ServicePrincipal -Tenant $TenantId -Credential $mycreds

        Set-AzureRmContext -SubscriptionID $AzureSubscriptionId -TenantId $TenantId;
        #endregion
    }
    else
    {
        #region Use Manual Login
        try 
        {
            Write-Host "inside try"
            Set-AzureRmContext -SubscriptionID $AzureSubscriptionId
        }
        catch 
        {
            Write-Host "inside catch"
            Login-AzureRmAccount
            Set-AzureRmContext -SubscriptionID $AzureSubscriptionId
        }
        #endregion      
    }

    Write-Host "Check if resource group already exists..."
    $notPresent = Get-AzureRmResourceGroup -Name $Name -ev notPresent -ea 0;

    if (!$notPresent) 
    {
        New-AzureRmResourceGroup -Name $Name -Location $location;
    }

    Write-Verbose "Starting ARM deployment...";
    New-AzureRmResourceGroupDeployment -Name $Name -ResourceGroupName $Name -TemplateFile $ArmTemplatePath -TemplateParameterObject $additionalParams; # -DeploymentDebugLogLevel All -Debug;

    Write-Host "Deployment Complete.";
}
catch 
{
    Write-Error $_.Exception.Message
    Break 
}