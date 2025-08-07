// See https://aka.ms/new-console-template for more information

using MusicDBPlayground.DiscogsIntegration;
using MusicDBPlayground.DiscogsIntegration.Security;

Console.WriteLine("Hello, World!");
using var client = new HttpClient();
var discogsClient = new DiscogsClient(client);
await discogsClient.AuthenticateAsync();



Console.ReadLine();
Console.WriteLine("Done!");