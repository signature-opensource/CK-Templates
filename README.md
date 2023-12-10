# CK-Templates

[![AppVeyor](https://ci.appveyor.com/api/projects/status/github/signature-opensource/CK-Templates?svg=true)](https://ci.appveyor.com/project/Signature-OpenSource/ck-templates)
[![Nuget](https://img.shields.io/nuget/vpre/CK.Templates.svg)](https://www.nuget.org/packages/CK.Templates/)
[![Licence](https://img.shields.io/github/license/signature-opensource/CK-Templates.svg)](https://img.shields.io/github/license/signature-opensource/CK-Templates/blob/master/LICENSE)

Install the templates:

```powershell
dotnet new --install ck.templates --nuget-source 'https://pkgs.dev.azure.com/Signature-OpenSource/Feeds/_packaging/NetCore4/nuget/v4/index.json'
```

<details>
<summary>[Optional] Install with dotnet 7+</summary>

Check your dotnet version first `dotnet --version`
> If version is 7+ you can use the new cli arguments without dashes

```powershell
 dotnet new install ck.templates --nuget-source 'https://pkgs.dev.azure.com/Signature-OpenSource/Feeds/_packaging/NetCore3/nuget/v3/index.json'
```

> Under version 7 keep using the previous command.
</details>

Create a new CK.DB solution:

```powershell
dotnet new ckdb
```

Create a new CK.DB project:

```powershell
dotnet new pckdb
```

Create a new CK.DB test project:

```powershell
dotnet new pckdbtest
```

## Available templates

| Identity | short | Description |
|----------|-------|-------------|
| CK.DB.Template | ckdb | Create a solution that brings a skeleton with sql package and table, setup ready, with sql unit test. |
| Project.CK.DB.Template | pckdb | Create a project that brings a skeleton with sql package and table. |
| Project.CK.DB.Tests.Template | pckdbtest | Create a test project for sql package. |

## Contribute

Templates are located in `templates` folder.

To install locally, first pack [CK.Templates](./CK.Templates/CK.Templates.csproj) with `dotnet pack` then install produced package with `dotnet new install 'path/to/package'`.

Remove with `dotnet new uninstall CK.Templates`.

Add new templates in [templates](./CK.Templates/templates) folder.

## CK.DB.Template

In folder [`ckdbsolutiontemplate`](./CK.Templates/templates/ckdbsolutiontemplate).

- Usage : `dotnet new ckdb`
- Usage : `dotnet new ckdb -o CK-DB-MyProject`
- Usage : `dotnet new ckdb -o MyProject`

> Note: CK.DB. or CK-DB- or CK_DB_ is absorbed.

And answer `y` to the unique prompt to create the git repository (git init).

## CK.DB.Tests.Template

In folder [`ckdbprojecttesttemplate`](./CK.Templates/templates/ckdbprojecttesttemplate).

> Note: Don't forget to refer the project to test.

## TODO

- CamelCase should start with a lowercase letter where needed (hard to do)
- Add maybe a template for item.
