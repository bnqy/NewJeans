using System.Net; //IPHostEntry, Dns, IPAddress
using static System.Console;

Write("Input URL address: ");
string? url = ReadLine();

if (string.IsNullOrWhiteSpace(url))
{
    url = @"https://demirbank.kg/ru/retail/pay-and-transfer/tax-payments-via-ib";
}

Uri uri = new Uri(url);

WriteLine($"URL: {url}");
WriteLine($"Scheme: {uri.Scheme}");
WriteLine($"Port: {uri.Port}");
WriteLine($"Host: {uri.Host}");
WriteLine($"Path: {uri.AbsolutePath}");
WriteLine($"Query: {uri.Query}");
WriteLine();

IPHostEntry entry = Dns.GetHostEntry(uri.Host);
WriteLine($"The {entry.HostName} has the following IP addresses:");
foreach (IPAddress ip in entry.AddressList)
{
    WriteLine($" {ip} ({ip.AddressFamily})");
}