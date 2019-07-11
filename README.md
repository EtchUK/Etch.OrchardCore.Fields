# Etch.OrchardCore.Fields

Module for [Orchard Core](https://github.com/OrchardCMS/OrchardCore) that provides useful content fields.

## Build Status

[![Build Status](https://secure.travis-ci.org/etchuk/Etch.OrchardCore.Fields.png?branch=master)](http://travis-ci.org/etchuk/Etch.OrchardCore.Widgets) [![NuGet](https://img.shields.io/nuget/v/Etch.OrchardCore.Fields.svg)](https://www.nuget.org/packages/Etch.OrchardCore.Fields)

## Orchard Core Reference

This module is referencing the beta 3 build of Orchard Core ([`1.0.0-beta3-71077`](https://www.nuget.org/packages/OrchardCore.Module.Targets/1.0.0-beta3-71077)).

## Installing

[Download the source](https://github.com/etchuk/Etch.OrchardCore.Fields/archive/master.zip) or clone the repository to your local machine. Add the project to your solution that contains an Orchard Core project and add a reference to Etch.OrchardCore.Fields.

Once the module is in a usable state we'll make it available via NuGet.

## Fields

Each content field is packaged as it's own feature that needs to be enabled.

### Dictionary

Provides content field for managing an arbitrary amount of names and associated values. Items will be displayed on the page as an unordered list with name/value.

![Screen recording of dictionary field](https://github.com/etchuk/Etch.OrchardCore.Fields/raw/master/docs/demo-dictionary-field.gif)

### Multi Select

Content field that has a collection of pre-configured options where content editors can choose multiple options that will be rendered in an unordered list.

![Screen recording of multi select field](https://github.com/etchuk/Etch.OrchardCore.Fields/raw/master/docs/demo-multi-select-field.gif)

### Render Alias

Allows editors to specify a content item by its alias to be rendered in a specified display type.

![Screen recording of render alias field](https://github.com/etchuk/Etch.OrchardCore.Fields/raw/master/docs/demo-render-alias-field.gif)

### Responsive Media

Replica of the media field, however the field can have responsive breakpoints configured, which will be used to display a responsive image via the `picture` element. Content editors can define specific images for particular breakpoints, otherwise a [dynamically resized image](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Media/README/#resize_url) will be used for the breakpoint.

_This field is still in development._

### Values

Content editors can define an arbitary list of values with a user friendly editor experience. Values will be displayed on the page as an unordered list.

![Screen recording of values field](https://github.com/etchuk/Etch.OrchardCore.Fields/raw/master/docs/demo-values-field.gif)
