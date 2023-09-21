using System.Text;
using static System.Console;

WriteLine("Encodings");
WriteLine("[1] ASCII");
WriteLine("[2] UTF-7");
WriteLine("[3] UTF-8");
WriteLine("[4] UTF-16 (Unicode)");
WriteLine("[5] UTF-32");
WriteLine("[any other key] Default");

Write("Press a number to choose an encoding: ");
ConsoleKey key = ReadKey(intercept: false).Key;
WriteLine();
WriteLine();

Encoding encoder = key switch
{
    ConsoleKey.D1 or ConsoleKey.NumPad1 => Encoding.ASCII,
    ConsoleKey.D2 or ConsoleKey.NumPad2 => Encoding.UTF7,
    ConsoleKey.D3 or ConsoleKey.NumPad3 => Encoding.UTF8,
    ConsoleKey.D4 or ConsoleKey.NumPad4 => Encoding.Unicode,
    ConsoleKey.D5 or ConsoleKey.NumPad5 => Encoding.UTF32,
    _ => Encoding.Default
};

string message = "Café cost: £4.39";

byte[] bytes = encoder.GetBytes(message);

WriteLine($"{encoder.GetType().Name} uses {bytes.Length} bytes");
WriteLine();

WriteLine($"BYTE HEX CHAR:");

foreach (byte b in bytes)
{
    WriteLine($"{b, 4} {b.ToString("X"), 4} {(char)b, 5}");
}

WriteLine();
string decoded = encoder.GetString(bytes);
WriteLine(decoded);    