# Etch.OrchardCore.Fields

Module for [Orchard Core](https://github.com/OrchardCMS/OrchardCore) that provides useful content fields.

## Build Status

[![Build Status](https://secure.travis-ci.org/etchuk/Etch.OrchardCore.Fields.png?branch=master)](http://travis-ci.org/etchuk/Etch.OrchardCore.Widgets)

_This module is currently under development and will be made available on NuGet when usable._

## Installing

[Download the source](https://github.com/etchuk/Etch.OrchardCore.Fields/archive/master.zip) or clone the repository to your local machine. Add the project to your solution that contains an Orchard Core project and add a reference to Etch.OrchardCore.Fields.

Once the module is in a usable state we'll make it available via NuGet.

## Fields

Each content field is packaged as it's own feature that needs to be enabled.

### Dictionary

Provides content field for managing an arbitrary amount of names and associated values. Items will be displayed on the page as an unordered list with name/value. Below is a screen recording of the field in action.

![Screen recording of dictionary field](https://github.com/etchuk/Etch.OrchardCore.Fields/raw/master/docs/demo-dictionary-field.gif)

### Responsive Media

Replica of the media field, however the field can have responsive breakpoints configured, which will be used to display a responsive image via the `picture` element. Content editors can define specific images for particular breakpoints, otherwise a [dynamically resized image](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Media/README/#resize_url) will be used for the breakpoint.

_This field is still in development._

### Values

Content editors can define an arbitary list of values with a user friendly editor experience. Values will be displayed on the page as an unordered list. Below is a screen recording of the field in action.

![Screen recording of values field](https://github.com/etchuk/Etch.OrchardCore.Fields/raw/master/docs/demo-values-field.gif)