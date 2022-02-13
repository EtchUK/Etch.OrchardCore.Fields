using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Useful Fields",
    Author = "Etch UK",
    Website = "https://etchuk.com",
    Version = "1.1.2"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.Code",
    Name = "Code Field",
    Description = "Field for defining code.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.Colour",
    Name = "Colour Field",
    Description = "Field for choosing a colour.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.Dictionary",
    Name = "Dictionary Field",
    Description = "Field for managing an arbitrary amount of names and associated values.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.Eventbrite",
    Name = "Eventbrite Field",
    Description = "Field for fetching information from an Eventbrite event.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.MultiSelect",
    Name = "Multi Select Field",
    Description = "Field for choosing multiple values from collection of configured options.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.Query",
    Name = "Query Field",
    Description = "Field for selecting a query.",
    Category = "Content",
    Dependencies = new[] { "OrchardCore.Queries" }
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.RenderAlias",
    Name = "Render Alias Field",
    Description = "Field for specifying an alias and display type to be rendered.",
    Category = "Content",
    Dependencies = new[] { "OrchardCore.Alias" }
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.ResponsiveMedia",
    Name = "Responsive Media Field",
    Dependencies = new[] { "OrchardCore.Media" },
    Description = "Field for managing responsive media content.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.Values",
    Name = "Values Field",
    Description = "Field for managing an arbitrary list of values.",
    Category = "Content"
)]