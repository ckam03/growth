namespace growth.Backend.Features.Unsplash;

public record UnsplashResponse(string Id, 
                               string Description, 
                               Urls Urls);

public record Urls(string Full, string Thumb);
