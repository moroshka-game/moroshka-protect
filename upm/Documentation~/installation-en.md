# Installation

## Table of Contents

- [Installation](#installation)
  - [Table of Contents](#table-of-contents)
  - [OpenUPM](#openupm)
    - [Unity Package Manager](#unity-package-manager)
    - [OpenUPM CLI](#openupm-cli)
  - [Unity Package Manager](#unity-package-manager-1)
    - [git url](#git-url)
    - [tarball](#tarball)
  - [NuGet](#nuget)
    - [NuGetForUnity](#nugetforunity)
    - [.NET](#net)

## OpenUPM

```url
https://openupm.com/packages/com.moroshka.protect.html
```

### Unity Package Manager

1. Open the Packages/manifest.json file in your project.
2. Add "scopedRegistries" if it doesn't exist yet:

``` json
{
  "scopedRegistries": [
    {
      "name": "OpenUPM",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.moroshka"
      ]
    }
  ],
  "dependencies": {
    "com.moroshka.protect": "#.#.#"
  }
}
```

### OpenUPM CLI

Install OpenUPM CLI (requires Node.js):

``` bash
npm install -g openupm-cli
```

In the project folder, run:

``` bash
openupm add com.moroshka.protect
```

## Unity Package Manager

### git url

1. Open Window → Package Manager.
2. Click + → Add package from git URL...
3. Enter the url and click Add.

```url
https://github.com/moroshka-game/moroshka-protect.git?path=upm#v#.#.#
```

### tarball

1. Download the .tgz.gz file of the desired version
2. Open Window → Package Manager.
3. Click + → Add package from tarball...
4. Select the downloaded .tgz.gz file and click Open.

``` url
https://github.com/moroshka-game/moroshka-protect/releases/
```

## NuGet

```url
https://www.nuget.org/packages/Moroshka.Protect
```

### NuGetForUnity

1. Add [NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity) to your project if it's not already there
2. After installation, a menu item will appear: NuGet → Manage NuGet Packages.
3. Open the manager, search for the package by name `Moroshka.Protect`.
4. Select the version and click Install.
5. The package will be added to the project as a standard .NET library (DLL).

### .NET

1. Open command line
2. Navigate to the directory containing the project file.
3. Run the command to install the NuGet package:

```sh
dotnet add package Moroshka.Protect -v #.#.#
```
