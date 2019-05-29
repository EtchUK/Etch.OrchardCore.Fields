using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Useful Fields",
    Author = "Etch UK",
    Website = "https://etchuk.com",
    Version = "0.4.0"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.ResponsiveMedia",
    Name = "Responsive Media Field",
    Dependencies = new[] { "OrchardCore.Media" },
    Description = "Provides content field for managing responsive media content.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.Dictionary",
    Name = "Dictionary Field",
    Description = "Provides content field for managing an arbitrary amount of names and associated values.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.Values",
    Name = "Values Field",
    Description = "Provides content field for managing an arbitrary list of values.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.RenderAlias",
    Name = "Render Alias Field",
    Description = "Provides field for specifying an alias and display type to be rendered.",
    Category = "Content",
    Dependencies = new[] { "OrchardCore.Alias" }
)]