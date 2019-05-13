using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Useful Fields",
    Author = "Etch UK",
    Website = "https://etchuk.com",
    Version = "0.0.1"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.ResponsiveMedia",
    Name = "Responsive Media Field",
    Description = "Provides content field for managing responsive media content.",
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Fields.Dictionary",
    Name = "Dictionary Field",
    Description = "Provides content field for managing an arbitrary amount of names and associated values.",
    Category = "Content"
)]