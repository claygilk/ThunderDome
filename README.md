# ThunderDome
## Two Monsters Enter One Monster Leaves ##

This is a stripped down D&D 5e combat simulator that I am making for practice.

## Build and Run

To build and run this project, first clone it from Github and navigate to the root of the project.  Open a terminal and run the following:

```sh
# Build
dotnet build ThunderDome/

# Rin
dotnet run --project ThunderDome/ThunderDome/ThunderDome.csproj
```

Other things to consider

Based on this [article](https://blog.markvincze.com/automated-portable-code-style-checking-in-net-core-projects/ )

```sh
dotnet add ThunderDome/ThunderDome/ThunderDome.csproj package StyleCop.Analyzers
```

After this, if you try to build your project, you’ll immediately receive the violations in the form of compiler warnings.

```sh
dotnet build ThunderDome/ --no-incremental
```
