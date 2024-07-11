# CK-Templates

[![AppVeyor](https://ci.appveyor.com/api/projects/status/github/signature-opensource/CK-Templates?svg=true)](https://ci.appveyor.com/project/Signature-OpenSource/ck-templates)
[![Nuget](https://img.shields.io/nuget/vpre/CK.Templates.svg)](https://www.nuget.org/packages/CK.Templates/)
[![Licence](https://img.shields.io/github/license/signature-opensource/CK-Templates.svg)](https://img.shields.io/github/license/signature-opensource/CK-Templates/blob/master/LICENSE)

Install the templates:

```powershell
 dotnet new install ck.templates --nuget-source 'https://pkgs.dev.azure.com/Signature-OpenSource/Feeds/_packaging/NetCore3/nuget/v3/index.json'
```

Create a new CK.DB solution:

```powershell
dotnet new ckdb-solution
```

Or, inside an existing solution:
- Create a new CK.DB project:
```powershell
dotnet new ckdb-project
```

- Create a new CK.DB test project:
```powershell
dotnet new ckdb-test-project
```

## Available templates

| Identity | short | Description |
|----------|-------|-------------|
| CK.DB.Template.Solution | ckdb-solution | Create a solution that brings a skeleton with sql package and table, setup ready, with sql unit test. |
| CK.DB.Template.Project | ckdb-project | Create a project that brings a skeleton with sql package and table. |
| CK.DB.Template.Tests.Project | ckdb-test-project | Create a test project for its sql package. |

## TODO

- "camelCase" should start with a lowercase letter where needed (hard to do)
- Template for item (SqlTable, SqlPackage)?
