using System.Text;
using System.Text.Json;
using HomeListingNotifier.Model.Remax;

namespace HomeListingNotifier;

public static class RemaxTestingFileDataStorage
{
    private static readonly string FilePath = Path.Combine(Environment.CurrentDirectory, "remax-data.json");

    public static async Task Set<TInput>(TInput data)
    {
        Lock();
        await using var writer = new StreamWriter(FilePath);
        
        var dataJson = JsonSerializer.Serialize(data);
        await writer.WriteAsync(dataJson);
    }

    public static async Task<ListingData[]> Get()
    {
        try
        {
            Lock();
            using var streamReader = new StreamReader(FilePath, Encoding.UTF8);
            var dataString = await streamReader.ReadToEndAsync();

            return JsonSerializer.Deserialize<ListingData[]>(dataString) ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return [];
        }
    }

    private static void Lock()
    {
        while (FileIsOpen())
        {
            
        }
    }

    private static bool FileIsOpen()
    {
        FileStream stream = null!;

        try
        {
            stream = File.Open(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            return true;
        }
        finally
        {
            stream.Close();
        }
        return false;
    }
}