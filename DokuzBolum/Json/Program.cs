using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Console;
using static System.Environment;
using static System.IO.Path;



Book book = new("Computer Networking for Dummies")
{
    Author = "Unknown",
    Publisheddate = new(2023, month: 10, 23),
    Created = DateTimeOffset.UtcNow,
    Pages = 781
};

JsonSerializerOptions options = new()
{
    IncludeFields = true,
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

string path = Combine(CurrentDirectory, "book.json");

using (Stream jsonStream = File.Create(path))
{
    JsonSerializer.Serialize<Book>(utf8Json: jsonStream, value: book, options);


}

WriteLine("Written {0:N0} bytes of JSON to {1}", new FileInfo(path).Length, path);
WriteLine();
WriteLine(File.ReadAllText(path));



public class Book
{
    public Book(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
    public string? Author { get; set; }

    [JsonInclude]
    public DateTime Publisheddate;

    [JsonInclude]
    public DateTimeOffset Created;

    public ushort Pages;
}