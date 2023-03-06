# CK-Templates

[![AppVeyor](https://ci.appveyor.com/api/projects/status/todo?svg=true)](https://ci.appveyor.com/project/Signature-OpenSource/ck-templates)
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

## Available templates

| Identity       | short | Description                                                                                           |
|----------------|-------|-------------------------------------------------------------------------------------------------------|
| CK.DB.Template | ckdb  | Create a solution that brings a skeleton with sql package and table, setup ready, with sql unit test. |

## Contribute

Templates are located in `templates` folder.

To install locally, first pack [CK.Templates](./CK.Templates/CK.Templates.csproj) with `dotnet pack` then install produced package with `dotnet new install 'path/to/package'`.

Remove with `dotnet new uninstall CK.Templates`.

Add new templates in [templates](./templates) folder.

## CK.DB.Template

In folder [`ckdbtemplate`](./templates/ckdbtemplate).

- Usage : `dotnet new ckdb`
- Usage : `dotnet new ckdb -o CK-DB-MyProject`
- Usage : `dotnet new ckdb -o MyProject`

> Note: CK.DB. or CK-DB- or CK_DB_ is absorbed.

And answer `y` to al the prompts to create the first commit.

## TODO

- Release first stable version to nuget.
- Update appveyor badge.
