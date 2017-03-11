# PaaSPort for Sitecore

PaaSPort is a tool for Sitecore developers that provides everything necessary to rapidly configure Azure resource visualization inside of the Sitecore Content Editor. 

PaaSPort is a Helix-compliant module designed to bring Azure resource information into the content tree for display as Sitecore items. It leverages Sitecore's Data Exchange Framework to retrieve data from Azure via custom pipelined service calls.

PaaSPort connects information about Azure resources to the Sitecore Client via Sitecore's [Data Exchange Framework](https://dev.sitecore.net/Downloads/Data_Exchange_Framework.aspx), by creating and syncing Sitecore items that represent the retrieved Azure resources. PaaSPort takes full advantage of Sitecore DXF's features, enabling developers to map Azure resource information to Sitecore items using highly-extensible field mappings that can be defined and customized with minimal effort. 

The current release of PaaSPort (v1.0.0-rc0 Technical Preview) includes support for retrieving Resource Groups from Azure and creating/syncing items in the Sitecore Content Tree to represent them, as an example of the features and capabilities that the module brings to your Sitecore solution.

## Version Compatibility/Requirements

- Sitecore version 8.1 rev. 151207 (8.1 update-1) or later
- Sitecore Data Exchange Framework version 1.3.0 rev 170206
- Sitecore Provider for Data Exchange Framework 1.3
- Azure Client SDK

## Features

PaaSPort ships with the following features:

- Azure Provider for Data Exchange Framework 1.3
- PaaSPort Service Pipeline abstractions
  - `<getResourceGroups>` service pipeline
- Demo Tenant
  - Runs on manual execution
  - Uses all included service pipelines

Upcoming Features:

- Improved, step-by-step configuration documentation
- Branch templates for adding new PaaSPort Service Pipeline Batches
- Branch templates for adding pre-configured base PaaSPort Endpoints
- Support for optionally nesting PaaSPort items
  - e.g. choose whether or not to next retrieved Azure SQL Server items under their respective Resource Groups
- Scheduler agent for running pipeline batches
- New service pipelines:
  - `<getAppServicePlans>`
  - `<getWebApps>`
  - `<getStorageAccounts>`
  - `<getVirtualMachines>`
  - `<getNetworks>`
  - `<getLoadBalancers>`
  - `<getSqlServers>`
  - `<getRedisCaches>`
  - `<getCdnProfiles>`
  - `<getDnsZones>`
  - `<getDisks>`
  - ...and more...
- Ability to send commands to Azure
- ...and more...

## Technical Overview

At its core, PaaSPort is a tool that gives you everything you need to rapidly configure Azure resource visualization inside of the Sitecore Content Editor, via Sitecore's [Data Exchange Framework](https://dev.sitecore.net/Downloads/Data_Exchange_Framework.aspx). 

Using PaaSPort, configuring end-to-end communication between Azure and Sitecore involves the following components:

- Azure Account with a Subscription containing Resource Groups (and optionally resources)
- PaaSPort Service Pipeline (responsible for communication with and data retrieval from Azure services)
- PaaSPort Data Exchange Endpoint (instance of Sitecore template included with PaaSPort)
- Sitecore Data Exchange Endpoint (instance of Siteore template included with Sitecore Provider for DXF 1.3)
- Data Exchange Framework (responsible for mapping data from PaaSPort Endpoint to Sitecore Endpoint)
- Target Location and Templates (templates to be used to display retrieved data and the location where instances of the templates should be added)

## Communication and Data Flow

...TODO: diagram coming soon...

## Key Concepts

### PaaSPort Visas

PaaSPort is designed to provide a modular approach to the synchronization and representation of Azure resouce information. As such, each resource that you display information for using PaaSPort requires it's own _Visa_. PaaSPort Visas describe the union of all of the components necessary to configure (but not execute) the end-to-end communication between Azure and Sitecore. A PaaSPort Visa includes all of the following:

- A _PaaSPort Service Pipeline_
- A _PaaSPort Data Exchange Endpoint_
- A _Sitecore Data Exchange Endpoint_
- A template for data to be stored in
- A location for the instances of the template to be created in
- A mapping between the data passed to the endpoints and the template 

Conceptually speaking, a PaaSPort Visa defines the following information about the data being retrieved from Azure:

- **Departure Location:** Where does the data come from?
  - PaaSPort Data Exchange Endpoint
  - A separate PaaSPort endpoint will be created for each Visa 
    - PaaSPort endpoints are not shared between PaaSPort Services
    - Each PaaSPort Endpoint represents the port of departure for a specific Azure service call 
      - e.g. "GET Resource Groups"
- **Arrival Location:** At which location in the Sitecore web application will the data arrive?
  - Sitecore Data Exchange Endpoint
  - Visas can share the same Sitecore Endpoint
    - Each Sitecore Endpoint represents the port of arrival to be used for service calls
    - Sitecore endpoints can be used by any number of service calls
    - Adding multiple Sitecore Endpoints is unnecessary, unless you want to customize how the Sitecore Endpoint works for some of the service calls
    - The Sitecore Endpoint is included in the Sitecore Provider for DXF 1.3
- **Transportation Information:** How does the data get from the Departure Location to the Arrival Location?
  - PaaSPort Service Pipelines
  - A separate PaaSPort Service Pipeline will be created for each Visa
    - Visas cannot share service pipelines
    - Each service pipeline controls the retrieval of data from Azure and any logic that is performed on the retrieved data before it is passed to the Sitecore Endpoint
- **Customs and Import Restrictions:** What parts of the data can actually be brought into Sitecore?
  - Includes both the template for storing the data and the mapping between the data passed to the endpoints and the template
  - Data Exchange value accessors are used to pull data from the object(s) returned from the service call
  - PaaSPort supports all custom value accessors and all value accessors included with the Data Exchange Framework
- **Final Destination:** Where in Sitecore will the data live after it gets here?
  - Location where instances of the Sitecore template for the data will be created
  - Locations may optionally be shared between Visas, depenending on your implementation
    - If you include code to delete items that are no longer retrieved from the Azure services then you will need to take care not to delete items that should be retrieved by other services
    
When extending or maintaining PaaSPort, it is important to ensure that you have all of the above created and configured for the data you wish to retrieve, or else you will receive errors and your data "will not be permitted entry" (or sometimes it will only be permitted "partial entry", depending on your Data Exchange Framework settings) into Sitecore.

**IMPORTANT:** Remember that _PaaSPort Visas_ are merely a concept for understanding the module. As such, there are no templates, code or configuration settings that represent a Visa on their own, but rather a Visa is defined by the collection of all of the templates, code and configuation settings that comprise each of the above components.

### PaaSPort Service Pipelines

Communication between Sitecore and Azure is managed by custom PaaSPort Service Pipelines that can be created, extended or removed with minimal effort. 

... TODO: add documentation for creating, extending and configuring PaaSPort Service Pipelines

### Data Exchange Endpoints

... TODO: add documentation for creating, extending and configuring PaaSPort and Sitecore Data Exchange Endpoints

## Reporting Issues

The project is regularly maintained, and new features/bug fixes will be made available as soon as possible. Please, report any issues you find via the [Issue Tracker](https://github.com/theinjectables/PaaSPort/issues), and we will get to them as quickly as we can.

## About the Project

PaaSPort was originally created as a submission for Sitecore Hackathon 2017. Unfortunately, we ran out of time to complete the module during the competition, so Zachary Kniebel (@zkniebel) completed the basic functionality and first release over the course of the following week. 

## Team Members

- Zachary Kniebel - @zkniebel
- Pete Navarra - [Tweet @SitecoreHacker](https://twitter.com/SitecoreHacker) - [GitHub: Vapok](https://github.com/vapok)
- Hetal Dave - @hetaldave
