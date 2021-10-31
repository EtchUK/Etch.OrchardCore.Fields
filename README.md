# Etch.OrchardCore.Fields

Module for [Orchard Core](https://github.com/OrchardCMS/OrchardCore) that provides useful content fields.

## Build Status

[![Build Status](https://secure.travis-ci.org/etchuk/Etch.OrchardCore.Fields.png?branch=master)](http://travis-ci.org/etchuk/Etch.OrchardCore.Fields) [![NuGet](https://img.shields.io/nuget/v/Etch.OrchardCore.Fields.svg)](https://www.nuget.org/packages/Etch.OrchardCore.Fields)

## Orchard Core Reference

This module is referencing a stable build of Orchard Core ([`1.1.0`](https://www.nuget.org/packages/OrchardCore.Module.Targets/1.1.0)).

## Installing

This module is available on [NuGet](https://www.nuget.org/packages/Etch.OrchardCore.Fields). Add a reference to your Orchard Core web project via the NuGet package manager. Search for "Etch.OrchardCore.Fields", ensuring include prereleases is checked.

Alternatively you can [download the source](https://github.com/etchuk/Etch.OrchardCore.Fields/archive/master.zip) or clone the repository to your local machine. Add the project to your solution that contains an Orchard Core project and add a reference to Etch.OrchardCore.Fields.

## Fields

Each content field is packaged as it's own feature that needs to be enabled.

### Code

Content field providing a code editor (using [Ace](https://ace.c9.io/)) to add code as content, perfect for displaying code samples.

![Screen recording of code field](/docs/demo-code-field.gif?raw=true)

### Colour

Colour field introduces an alternative to the `TextField` for ditors to define a colour. This field can be configured with a colour palette, transparent or the ability to choose a custom colour.

### Dictionary

Provides content field for managing an arbitrary amount of names and associated values. Items will be displayed on the page as an unordered list with name/value.

![Screen recording of dictionary field](/docs/demo-dictionary-field.gif?raw=true)

### Eventbrite

Provides a content field that will fetch event data from Eventbrite and display it as an unordered list.

### Multi Select

Content field that has a collection of pre-configured options where content editors can choose multiple options that will be rendered in an unordered list.

![Screen recording of multi select field](/docs/demo-multi-select-field.gif?raw=true)

### Query

Editors can choose from a drop down list of [queries](https://docs.orchardcore.net/en/dev/docs/reference/modules/Queries/).

### Render Alias

Allows editors to specify a content item by its alias to be rendered in a specified display type.

![Screen recording of render alias field](/docs/demo-render-alias-field.gif?raw=true)

### Responsive Media

Replica of the media field, however the field can have responsive breakpoints configured, which will be used to display a responsive image via the `picture` element. Content editors can define specific images for particular breakpoints, otherwise a [dynamically resized image](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Media/README/#resize_url) will be used for the breakpoint.

### Values

Content editors can define an arbitary list of values with a user friendly editor experience. Values will be displayed on the page as an unordered list.

![Screen recording of values field](/docs/demo-values-field.gif?raw=true)
