using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Useful Fields",
    Author = "Moov2",
    Website = "https://moov2.com",
    Version = "0.0.1"
)]

[assembly: Feature(
    Id = "Moov2.OrchardCore.Fields.ResponsiveMedia",
    Name = "Responsive Media Field",
    Description = "Provides content field for managing responsive media content.",
    Category = "Content"
)]