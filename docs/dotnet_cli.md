# Dotnet  CLI

## Introduction

The .NET CLI (Command Line Interface) is a cross-platform toolchain for developing, building, running, and publishing .NET applications. It is a powerful tool that allows developers to create and manage .NET projects from the command line.

## Install

```bash
sudo apt-get install -y dotnet-sdk-7.0
```
## Usage

```bash
dotnet new console -n MyApp
cd MyApp
dotnet run
```
## Build

```bash
dotnet build
```
## Run

```bash
dotnet run
```

## Watch

```bash
dotnet watch
```

## Publish

```bash
dotnet publish -c Release -o ./publish
```
## Test

```bash
dotnet test
```
## Clean

```bash
dotnet clean
```
## Add Package

```bash
dotnet add package <package_name>
```
## Remove Package

```bash
dotnet remove package <package_name>
```
## Add Reference

```bash
dotnet add reference <project_file>
```