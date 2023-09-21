using static System.Console;
using System.Xml;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;

//WorkWithText();
WorkWithCompression();


static void WorkWithCompression()
{
    string fileExt = "gzip";

    string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");

    FileStream file = File.Create(filePath);

    Stream compressor = new GZipStream(file, CompressionMode.Compress);

    using (compressor)
    {
        using (XmlWriter xml = XmlWriter.Create(compressor))
        {
            xml.WriteStartDocument();
            xml.WriteStartElement("callsigns");

            foreach (string str in Viper.Callsighns)
            {
                xml.WriteElementString("callsigns", str);
            }
        }
    }

    WriteLine($"{filePath} contains {new FileInfo(filePath).Length} bytes");
    WriteLine($"\nThe compressed content:");
    WriteLine($"{File.ReadAllText(filePath)}");

    WriteLine($"\nReading the compressed XML file: ");
    file = File.Open(filePath, FileMode.Open);


    Stream decompressor = new GZipStream(file, CompressionMode.Decompress);

    using (decompressor)
    {
        using (XmlReader reader = XmlReader.Create(decompressor))
        {
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsigns"))
                {
                    reader.Read();

                    WriteLine($" {reader.Value}");
                }

            }

        }
    }

}


static void WorkWithText()
{
    string txtFile = Combine(CurrentDirectory, "streams.txt");
    StreamWriter streamWriter = File.CreateText(txtFile);

    foreach (string str in Viper.Callsighns)
    {
        streamWriter.WriteLine(str);
    }
    streamWriter.Close();

    WriteLine($"{GetFileName(txtFile)} contains {new FileInfo(txtFile).Length}");

    WriteLine($"{File.ReadAllText(txtFile)}");
    WriteLine(txtFile);
}



static class Viper
{
    public static string[] Callsighns = new[] 
    {
        "Husker", "Starbuck", "Apollo", "Boomer",
        "Bulldog", "Athena", "Helo", "Racetrack"
    };
}
