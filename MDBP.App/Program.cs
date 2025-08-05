// See https://aka.ms/new-console-template for more information

using MusicDBPlayground.DiscogsIntegration;

Console.WriteLine("Hello, World!");
using var client = new HttpClient();
var discogsClient = new DiscogsOAuthClient(client);
var result = discogsClient.AuthorizeWithOAuth1();


Console.ReadLine();
Console.WriteLine("Done!");