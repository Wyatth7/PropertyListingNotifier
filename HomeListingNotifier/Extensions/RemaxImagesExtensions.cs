using HomeListingNotifier.Model.Remax;

namespace HomeListingNotifier.Extensions;

public static class RemaxImagesExtensions
{
    public static string GetBaseImageUrl(this RemaxImages[]? images)
    {
        if (images is null) return string.Empty;

        return images.FirstOrDefault()?.ComputedUrl ?? string.Empty;
    }
}