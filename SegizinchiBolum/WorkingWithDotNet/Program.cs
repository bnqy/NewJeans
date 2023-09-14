using System.Net; //IPHostEntry, Dns, IPAddress
using System.Net.NetworkInformation;
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

try
{
    Ping ping = new();
    WriteLine($"Pinging server, please wait...");
    PingReply reply = ping.Send(uri.Host);

    WriteLine($"{uri.Host} pinged and replied {reply.Status}");

    if (reply.Status == IPStatus.Success)
    {
        WriteLine($"Reply from {reply.Address} took {reply.RoundtripTime}ms");
    }
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
}