
MiNET (CobwebSMP edition)
=====
[![Build status](https://github.com/CobwebSMP/MiNET/actions/workflows/dotnet.yml/badge.svg)](https://github.com/CobwebSMP/MiNET/actions/workflows/dotnet.yml)
[![NuGet Version](https://img.shields.io/nuget/v/MiNET-CobwebSMP.svg) 
[![Downloads count](https://img.shields.io/nuget/dt/MiNET-CobwebSMP.svg) 

## Warning!

As a result of our network shut down updates for this software may be delayed, incomplete or even stopped.
Consider migrating to: [CRPE-Team/MiNET](https://github.com/CRPE-Team/MiNET)

## What is this?

This is fork of [MiNET](https://github.com/NiclasOlofsson/MiNET), that includes additional changes and features:

 - Latest Minecraft Bedrock Edition support
 - 1.13 world format support
 - Basic redstone functions
 - Rebuilt resources and formats for easier updating
 - Emotes
 - And more

## Getting started
Windows:

Download minet.zip from [Releases](https://github.com/CobwebSMP/MiNET/releases), extract MiNET folder, run MiNET.Console.exe.
This action will also create Worlds, Plugins and ResourcePacks folders.

Linux:

Download minet.zip from [Releases](https://github.com/CobwebSMP/MiNET/releases), extract MiNET folder, do "dotnet MiNET.Console.dll".
This action will also create Worlds, Plugins and ResourcePacks folders.

**Worlds** - You can load world LevelDB files exported with Minecraft Bedrock Edition 1.13 or converted to 1.13 format with [Chunker.app](https://chunker.app/). World data (level.dat, .... ) have to extracted in Worlds folder.

**Plugins** - There isn't many plugins for MiNET but here and there you may find some or you can made one. Useful links: [Plugin documention](https://github.com/NiclasOlofsson/MiNET/wiki/Plugin-API-Documentation), [MiNET TestPlugin](https://github.com/NiclasOlofsson/MiNET/tree/master/src/MiNET/TestPlugin)

**ResourcePacks** - Resource packs made for the latest game version should work also here. If you got pack with .mcpack extension, just rename it to .zip and it's good to go.

## Stability
Since this software is used and maintained for our server purposes, this may not contain all features, updates and fixes.

But if you found something you can always open an issue or pull request if you have solution.

## Plugins
Here are few plugins for MiNET that you can try:

 - [Chairs](https://github.com/CobwebSMP/Chairs)
 - [MiPermissionsNET](https://github.com/CupidonSauce173/MiPermissionsNET)
 - [SnowFall](https://github.com/laz1444/SnowFall)
 - [WorldEdit](https://github.com/CobwebSMP/WorldEdit)

