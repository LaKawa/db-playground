// See https://aka.ms/new-console-template for more information

using MusicDBPlayground.DiscogsIntegration;

Console.WriteLine("Hello, World!");
using var client = new HttpClient();
var discogsClient = new DiscogsOAuthClient(client);
await discogsClient.GetRequestTokenAsync();

Console.WriteLine("Done!");