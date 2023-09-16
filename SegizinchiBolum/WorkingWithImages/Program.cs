using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

//string imagesFolder = Path.Combine(Environment.CurrentDirectory, "images");
string imagesFolder = @"C:\Users\Lenovo\Desktop\C#App\NewJeans\SegizinchiBolum\WorkingWithImages\images";
Console.WriteLine($"Directory: {imagesFolder}");

IEnumerable<string> images = Directory.EnumerateFiles(imagesFolder);

foreach (string imagePath in images)
{
    string thumbnailPath = Path.Combine(imagesFolder, Path.GetFileNameWithoutExtension(imagePath) + "-thumbnail" + Path.GetExtension(imagePath));

    using (Image image = Image.Load(imagePath))
    {
        image.Mutate(x => x.Resize(image.Width/10, image.Height/10));
        image.Mutate(x => x.Grayscale());
        image.Save(thumbnailPath);
    }
}

Console.WriteLine("Image processing complete.");